using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace imageLab2
{
    class Filters
    {
        public double[] erlang;
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public Bitmap ExponentialNoise(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            byte[] noise = new byte[bytes];
            erlang = new double[256];
            double a = 5;
            Random rnd = new Random();
            double sum = 0;

            for (int i = 0; i < 256; i++)
            {
                double step = (double)i * 0.01;
                if (step >= 0)
                {
                    erlang[i] = (double)(a * Math.Exp(-a * step));
                }
                else
                {
                    erlang[i] = 0;
                }
                sum += erlang[i];
            }

            for (int i = 0; i < 256; i++)
            {
                erlang[i] /= sum;
                erlang[i] *= bytes;
                erlang[i] = (int)Math.Floor(erlang[i]);
            }

            int count = 0;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)erlang[i]; j++)
                {
                    noise[j + count] = (byte)i;
                }
                count += (int)erlang[i];
            }

            for (int i = 0; i < bytes - count; i++)
            {
                noise[count + i] = 0;
            }

            noise = noise.OrderBy(x => rnd.Next()).ToArray();

            for (int i = 0; i < bytes; i++)
            {
                result[i] = (byte)(buffer[i] + noise[i]);
            }

            Bitmap result_image = new Bitmap(w, h);
            BitmapData result_data = result_image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            Marshal.Copy(result, 0, result_data.Scan0, bytes);
            result_image.UnlockBits(result_data);

            return result_image;
        }


        public Bitmap GaussianFilter(Bitmap bmp)
        {
            Bitmap rezultImage = new Bitmap(bmp);

            int i, j, k, m, count;
            int R, G, B;
            int[] Red, Green, Blue;

            //Матрица для этого фильтра будет иметь вид:
            // 1 2 1 | A0 A1 A2
            // 2 4 2 | A3 A4 A5
            // 1 2 1 | A6 A7 A8

            for (i = 1; i < (bmp.Width - 1); i++)
            {
                for (j = 1; j < (bmp.Height - 1); j++)
                {
                    Red = new int[9];
                    Green = new int[9];
                    Blue = new int[9];
                    count = 0;

                    for (k = -1; k <= 1; k++)
                    {
                        for (m = -1; m <= 1; m++)
                        {
                            Red[count] = bmp.GetPixel(i + k, j + m).R;
                            Green[count] = bmp.GetPixel(i + k, j + m).G;
                            Blue[count] = bmp.GetPixel(i + k, j + m).B;
                            count++;
                        }
                    }

                    //Находим сумму R,G,B в окне фильтра 3х3
                    R = Red[0] + 2 * Red[1] + Red[2] + 2 * Red[3] + 4 * Red[4] + 2 * Red[5] + Red[6] + 2 * Red[7] + Red[8];
                    G = Green[0] + 2 * Green[1] + Green[2] + 2 * Green[3] + 4 * Green[4] + 2 * Green[5] + Green[6] + 2 * Green[7] + Green[8];
                    B = Blue[0] + 2 * Blue[1] + Blue[2] + 2 * Blue[3] + 4 * Blue[4] + 2 * Blue[5] + Blue[6] + 2 * Blue[7] + Blue[8];

                    //Делим полученные значения на сумму коэффициентов матрицы
                    R = R / 16;
                    G = G / 16;
                    B = B / 16;

                    //Помещаем полученные значения средних в центральный пиксель i, j
                    rezultImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return rezultImage;
        }

        int SearchNear(int[] M, int index, int k)
        {
            int rezultSumm = 0;
            int count = k;
            int forward, backward;

            //Отступаем на шаг вперед и назад от элемента, расположенного в центре окна (index равен середине выборки)
            forward = 1;
            backward = -1;

            //Выполняем, пока не найдем K ближайших элементов
            while (count != 0)
            {
                //Если индексы шага вперед и назад находятся в пределах массива
                if ((index + forward) < M.Length && (index + backward) >= 0)
                {
                    //Находим тот элемент, который менее отличается от центрального и суммируем его
                    if (Math.Abs(M[index + forward] - M[index]) <= Math.Abs(M[index + backward] - M[index]))
                    {
                        rezultSumm = rezultSumm + M[index + forward];
                        forward++;
                    }

                    else
                    {
                        rezultSumm = rezultSumm + M[index + backward];
                        backward--;
                    }
                }

                //Если индекс шага назад вышел за пределы массива - суммируем только по шагу вперед
                else if ((index + forward) <= M.Length && (index + backward) < 0)
                {
                    rezultSumm = rezultSumm + M[index + forward];
                    forward++;
                }

                //Если индекс шага вперед вышел за пределы массива - суммируем только по шагу назад
                else
                {
                    rezultSumm = rezultSumm + M[index + backward];
                    backward--;
                }
                count--;
            }

            //Находим среднее значение
            rezultSumm = rezultSumm / k;
            return rezultSumm;
        }

        public Bitmap AlphaTrunc(Bitmap bmp)
        {
            Bitmap rezultImage = new Bitmap(bmp);

            int i, j, k, m, count;
            int[] R, G, B;
            int Rc, Gc, Bc;

            double alpha;

            R = new int[9];
            G = new int[9];
            B = new int[9];

            //Для примера возьмем альфа=0.7 (т.е. отсечется 30% крайних значений)
            alpha = 0.7;

            //На элементы будет наложена матрица вида:
            // 1 1 1
            // 1 1 1
            // 1 1 1

            for (i = 1; i < (rezultImage.Width - 1); i++)
            {
                for (j = 1; j < (rezultImage.Height - 1); j++)
                {
                    count = 0;
                    //Считываем уровни всех пикселей для красного в окне фильтра
                    for (k = -1; k <= 1; k++)
                    {
                        for (m = -1; m <= 1; m++)
                        {
                            R[count] = bmp.GetPixel(i + k, j + m).R;
                            G[count] = bmp.GetPixel(i + k, j + m).G;
                            B[count] = bmp.GetPixel(i + k, j + m).B;
                            count++;
                        }
                    }

                    //Выполняем сортировку полученных массивов при помощи стандартных методов С#
                    Array.Sort(R);
                    Array.Sort(G);
                    Array.Sort(B);

                    //Получаем среднее alpha*n ближайших соседей
                    Rc = SearchNear(R, 4, (int)(alpha * 9));
                    Gc = SearchNear(G, 4, (int)(alpha * 9));
                    Bc = SearchNear(B, 4, (int)(alpha * 9));

                    //Помещаем средние значения на место центрального в окне фильтра
                    rezultImage.SetPixel(i, j, Color.FromArgb(Rc, Gc, Bc));
                }
            }
            return rezultImage;
        }

    }
}
