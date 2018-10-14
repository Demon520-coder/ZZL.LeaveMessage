﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZZL.LeaveMessage.Common
{
    /// <summary>
    /// 验证码类
    /// </summary>
    public class ValidateCode
    {
        //字段:验证码长度,验证码类型,验证码来源  1.产生随机验证码;2.绘制验证码;
        private const string _codeStr = "1,2,3,4,5,6,7,8,9,0,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";

        /// <summary>
        /// 验证码长度
        /// </summary>
        private int _length;
        /// <summary>
        /// 验证码干扰线
        /// </summary>
        private int Lines
        {
            get
            {
                return 30;
            }
        }
        /// <summary>
        /// 验证码干扰点
        /// </summary>
        public int BitmapPoints
        {
            get
            {
                return 100;
            }
        }

        private ValidateType _type;

        public readonly string _code;

        public ValidateCode(ValidateType type = ValidateType.Mix, int length = 4)
        {
            this._length = length;
            this._type = type;
            this._code = CreateValidateCode();
        }


        public string CreateValidateCode()
        {
            //获得验证码长度;获得验证码来源;随机数;
            Random rd = new Random();
            List<string> list = new List<string>();
            string[] codes = _codeStr.Split(',');
            for (int i = 0; i < _length; i++)
            {
                int rdNum = rd.Next(codes.Length);
                var rdCode = codes[rdNum];
                //判断类型:
                if (_type == ValidateType.AllNumber) //纯数字
                {
                    if (!rdCode.IsInt())
                    {
                        i--;
                        continue;
                    }

                }
                else if (_type == ValidateType.AllLetter) //纯字母
                {
                    if (rdCode.IsInt())
                    {
                        i--;
                        continue;
                    }
                }

                list.Add(rdCode);
            }

            return string.Join("", list);
        }

        /// <summary>
        /// 画验证码
        /// </summary>
        /// <returns></returns>
        public byte[] DrawValidateCode()
        {
            //1.获得验证码;
            //2.准备画笔与画布;
            Bitmap map = new Bitmap(_code.Length * 25, 40);
            using (Graphics g = Graphics.FromImage(map))
            {
                g.Clear(Color.White);
                //3.绘制图片边框、干扰线与躁点;
                g.DrawRectangle(new Pen(Color.Red), new Rectangle(0, 0, map.Width - 1, map.Height - 1));
              
                //4.绘制验证码;
                g.DrawString(_code, new Font("宋体", 25, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Blue), new Rectangle(0, 0, map.Width, map.Height));
                Random rd = new Random();
                //设置干扰线
                for (int i = 0; i < Lines; i++)
                {
                    Pen pen = new Pen(Color.Orange);
                    int x1 = rd.Next(map.Width);
                    int y1 = rd.Next(map.Height);
                    int x2 = rd.Next(map.Width);
                    int y2 = rd.Next(map.Height);

                    g.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                }

                //设置干扰点
                for (int i = 0; i < BitmapPoints; i++)
                {
                    map.SetPixel(rd.Next(map.Width), rd.Next(map.Height), Color.Green);
                }
                g.Save();
                //5.保存画好的验证码图片至字节数组;
                MemoryStream stream = new MemoryStream();
                map.Save(stream, ImageFormat.Bmp);

                return stream.ToArray();
            }

        }


    }

    public enum ValidateType
    {
        /// <summary>
        /// 纯数字
        /// </summary>
        AllNumber,
        /// <summary>
        /// 纯字母
        /// </summary>
        AllLetter,
        /// <summary>
        /// 混合
        /// </summary>
        Mix
    }
}
