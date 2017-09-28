using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Sample
{
    public class BitmapFormat
    {
        public struct BITMAPFILEHEADER
        {
            public ushort bfType;
            public int bfSize;
            public ushort bfReserved1;
            public ushort bfReserved2;
            public int bfOffBits;
        }

        public struct MASK
        {
            public byte redmask;
            public byte greenmask;
            public byte bluemask;
            public byte rgbReserved;
        }

        public struct BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }

        /*******************************************
        * �������ƣ�RotatePic
        * �������ܣ���תͼƬ��Ŀ���Ǳ�������ʾ��ͼƬ�밴��ָ�Ʒ�����ͬ
        * �������Σ�BmpBuf---��תǰ��ָ���ַ���
        * �������Σ�ResBuf---��ת����ָ���ַ���
        * �������أ���
        *********************************************/
        public static void RotatePic(byte[] BmpBuf, int width, int height, ref byte[] ResBuf)
        {
            int RowLoop = 0;
            int ColLoop = 0;
            int BmpBuflen = width * height;

            try
            {
                for (RowLoop = 0; RowLoop < BmpBuflen; )
                {
                    for (ColLoop = 0; ColLoop < width; ColLoop++)
                    {
                        ResBuf[RowLoop + ColLoop] = BmpBuf[BmpBuflen - RowLoop - width + ColLoop];
                    }

                    RowLoop = RowLoop + width;
                }
            }
            catch (Exception ex)
            {
                //ZKCE.SysException.ZKCELogger logger = new ZKCE.SysException.ZKCELogger(ex);
                //logger.Append();
            }
        }

        /*******************************************
        * �������ƣ�StructToBytes
        * �������ܣ����ṹ��ת�����޷����ַ�������
        * �������Σ�StructObj---��ת���Ľṹ��
        *           Size---��ת���Ľṹ���Ĵ�С
        * �������Σ���
        * �������أ��ṹ��ת����������
        *********************************************/
        public static byte[] StructToBytes(object StructObj, int Size)
        {
            int StructSize = Marshal.SizeOf(StructObj);
            byte[] GetBytes = new byte[StructSize];

            try
            {
                IntPtr StructPtr = Marshal.AllocHGlobal(StructSize);
                Marshal.StructureToPtr(StructObj, StructPtr, false);
                Marshal.Copy(StructPtr, GetBytes, 0, StructSize);
                Marshal.FreeHGlobal(StructPtr);

                if (Size == 14)
                {
                    byte[] NewBytes = new byte[Size];
                    int Count = 0;
                    int Loop = 0;

                    for (Loop = 0; Loop < StructSize; Loop++)
                    {
                        if (Loop != 2 && Loop != 3)
                        {
                            NewBytes[Count] = GetBytes[Loop];
                            Count++;
                        }
                    }

                    return NewBytes;
                }
                else
                {
                    return GetBytes;
                }
            }
            catch (Exception ex)
            {
                //ZKCE.SysException.ZKCELogger logger = new ZKCE.SysException.ZKCELogger(ex);
                //logger.Append();

                return GetBytes;
            }
        }

        /*******************************************
        * �������ƣ�GetBitmap
        * �������ܣ��������������ݱ���ΪͼƬ
        * �������Σ�buffer---ͼƬ����
        *           nWidth---ͼƬ�Ŀ���
        *           nHeight---ͼƬ�ĸ߶�
        * �������Σ���
        * �������أ���
        *********************************************/
        public static void GetBitmap(byte[] buffer, int nWidth, int nHeight, ref MemoryStream ms)
        {
            int ColorIndex = 0;
            ushort m_nBitCount = 8;
            int m_nColorTableEntries = 256;
            byte[] ResBuf = new byte[nWidth * nHeight];

            try
            {
                BITMAPFILEHEADER BmpHeader = new BITMAPFILEHEADER();
                BITMAPINFOHEADER BmpInfoHeader = new BITMAPINFOHEADER();
                MASK[] ColorMask = new MASK[m_nColorTableEntries];

                //ͼƬͷ��Ϣ
                BmpInfoHeader.biSize = Marshal.SizeOf(BmpInfoHeader);
                BmpInfoHeader.biWidth = nWidth;
                BmpInfoHeader.biHeight = nHeight;
                BmpInfoHeader.biPlanes = 1;
                BmpInfoHeader.biBitCount = m_nBitCount;
                BmpInfoHeader.biCompression = 0;
                BmpInfoHeader.biSizeImage = 0;
                BmpInfoHeader.biXPelsPerMeter = 0;
                BmpInfoHeader.biYPelsPerMeter = 0;
                BmpInfoHeader.biClrUsed = m_nColorTableEntries;
                BmpInfoHeader.biClrImportant = m_nColorTableEntries;

                //�ļ�ͷ��Ϣ
                BmpHeader.bfType = 0x4D42;
                BmpHeader.bfOffBits = 14 + Marshal.SizeOf(BmpInfoHeader) + BmpInfoHeader.biClrUsed * 4;
                BmpHeader.bfSize = BmpHeader.bfOffBits + ((((BmpInfoHeader.biWidth * BmpInfoHeader.biBitCount + 31) / 32) * 4) * BmpInfoHeader.biHeight);
                BmpHeader.bfReserved1 = 0;
                BmpHeader.bfReserved2 = 0;

                ms.Write(StructToBytes(BmpHeader, 14), 0, 14);
                ms.Write(StructToBytes(BmpInfoHeader, Marshal.SizeOf(BmpInfoHeader)), 0, Marshal.SizeOf(BmpInfoHeader));

                //���԰���Ϣ
                for (ColorIndex = 0; ColorIndex < m_nColorTableEntries; ColorIndex++)
                {
                    ColorMask[ColorIndex].redmask = (byte)ColorIndex;
                    ColorMask[ColorIndex].greenmask = (byte)ColorIndex;
                    ColorMask[ColorIndex].bluemask = (byte)ColorIndex;
                    ColorMask[ColorIndex].rgbReserved = 0;

                    ms.Write(StructToBytes(ColorMask[ColorIndex], Marshal.SizeOf(ColorMask[ColorIndex])), 0, Marshal.SizeOf(ColorMask[ColorIndex]));
                }

                //ͼƬ��ת������ָ��ͼƬ����������
                RotatePic(buffer, nWidth, nHeight, ref ResBuf);

                ms.Write(ResBuf, 0, nWidth * nHeight);
            }
            catch (Exception ex)
            {
               // ZKCE.SysException.ZKCELogger logger = new ZKCE.SysException.ZKCELogger(ex);
               // logger.Append();
            }
        }

        /*******************************************
        * �������ƣ�WriteBitmap
        * �������ܣ��������������ݱ���ΪͼƬ
        * �������Σ�buffer---ͼƬ����
        *           nWidth---ͼƬ�Ŀ���
        *           nHeight---ͼƬ�ĸ߶�
        * �������Σ���
        * �������أ���
        *********************************************/
        public static void POSTfile(int nName)
            {
                string boundary = "----WebKitFormBoundary6FkgYgZTPaBWWzxk";
                string name = String.Format(".\\image\\{0}.bmp", nName);
                string filename = String.Format("Content-Disposition: form-data; name=\"file\"; filename=\"{0}.bmp\"", nName);

                WebRequest req = WebRequest.Create(@"http://192.168.230.217/upload");
                req.Method = "POST";
                req.Timeout = 30000;
                req.ContentType = "multipart/form-data; boundary=" + boundary;

                StringBuilder sb = new StringBuilder();

                sb.Append("--" + boundary);
                sb.Append("\r\n");
                sb.Append(filename);
                sb.Append("\r\n");
                sb.Append("Content-Type: image/bmp");
                sb.Append("\r\n\r\n");

                string head = sb.ToString();
                byte[] form_data = Encoding.UTF8.GetBytes(head);
                byte[] foot_data = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                FileStream fileStream = new FileStream(name, FileMode.Open, FileAccess.Read);
                long length = form_data.Length + fileStream.Length + foot_data.Length;
                req.ContentLength = length;

                Stream requestStream = req.GetRequestStream();
                requestStream.Write(form_data, 0, form_data.Length);
                byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    requestStream.Write(buffer, 0, bytesRead);
                requestStream.Write(foot_data, 0, foot_data.Length);
                requestStream.Close();
            }
         public static void HttpGet()
           {
               WebRequest req = WebRequest.Create(@"http://192.168.230.217/upload");
               req.Method = "GET";
               req.ContentType = "text/html;charset=UTF-8";   
               req.GetResponse();
           }
        
        public static void WriteBitmap(byte[] buffer, int nWidth, int nHeight, int nName)
        {
            int ColorIndex = 0;
            ushort m_nBitCount = 8;
            int m_nColorTableEntries = 256;
            byte[] ResBuf = new byte[nWidth * nHeight];
            string name;

            try
            {

                BITMAPFILEHEADER BmpHeader = new BITMAPFILEHEADER();
                BITMAPINFOHEADER BmpInfoHeader = new BITMAPINFOHEADER();
                MASK[] ColorMask = new MASK[m_nColorTableEntries];

                //ͼƬͷ��Ϣ
                BmpInfoHeader.biSize = Marshal.SizeOf(BmpInfoHeader);
                BmpInfoHeader.biWidth = nWidth;
                BmpInfoHeader.biHeight = nHeight;
                BmpInfoHeader.biPlanes = 1;
                BmpInfoHeader.biBitCount = m_nBitCount;
                BmpInfoHeader.biCompression = 0;
                BmpInfoHeader.biSizeImage = 0;
                BmpInfoHeader.biXPelsPerMeter = 0;
                BmpInfoHeader.biYPelsPerMeter = 0;
                BmpInfoHeader.biClrUsed = m_nColorTableEntries;
                BmpInfoHeader.biClrImportant = m_nColorTableEntries;

                //�ļ�ͷ��Ϣ
                BmpHeader.bfType = 0x4D42;
                BmpHeader.bfOffBits = 14 + Marshal.SizeOf(BmpInfoHeader) + BmpInfoHeader.biClrUsed * 4;
                BmpHeader.bfSize = BmpHeader.bfOffBits + ((((BmpInfoHeader.biWidth * BmpInfoHeader.biBitCount + 31) / 32) * 4) * BmpInfoHeader.biHeight);
                BmpHeader.bfReserved1 = 0;
                BmpHeader.bfReserved2 = 0;

                name = String.Format(".\\image\\{0}.bmp", nName);
                Stream FileStream = File.Open(name, FileMode.Create, FileAccess.Write);
                BinaryWriter TmpBinaryWriter = new BinaryWriter(FileStream);

                TmpBinaryWriter.Write(StructToBytes(BmpHeader, 14));
                TmpBinaryWriter.Write(StructToBytes(BmpInfoHeader, Marshal.SizeOf(BmpInfoHeader)));

                //���԰���Ϣ
                for (ColorIndex = 0; ColorIndex < m_nColorTableEntries; ColorIndex++)
                {
                    ColorMask[ColorIndex].redmask = (byte)ColorIndex;
                    ColorMask[ColorIndex].greenmask = (byte)ColorIndex;
                    ColorMask[ColorIndex].bluemask = (byte)ColorIndex;
                    ColorMask[ColorIndex].rgbReserved = 0;

                    TmpBinaryWriter.Write(StructToBytes(ColorMask[ColorIndex], Marshal.SizeOf(ColorMask[ColorIndex])));
                }

                //ͼƬ��ת������ָ��ͼƬ����������
                RotatePic(buffer, nWidth, nHeight, ref ResBuf);

                //дͼƬ
                TmpBinaryWriter.Write(ResBuf);

                FileStream.Close();
                TmpBinaryWriter.Close();
            }
            catch (Exception ex)
            {
                //ZKCE.SysException.ZKCELogger logger = new ZKCE.SysException.ZKCELogger(ex);
                //logger.Append();
            }
        }
    }
}
