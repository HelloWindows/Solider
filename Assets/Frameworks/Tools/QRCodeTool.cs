/*******************************************************************
 * FileName: QRCodeTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2017-xxxx 
 *******************************************************************/
using UnityEngine;
using ZXing;
using ZXing.QrCode;

namespace Framework {
    namespace Tools {
        public class QRCodeTool {

            //定义方法生成二维码  
            public static Color32[] Encode(string textForEncoding, int width, int height) {

                BarcodeWriter writer = new BarcodeWriter {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions {
                        Height = height,
                        Width = width
                    }
                };
                return writer.Write(textForEncoding);
            } // end Encode
        } // end class QRCodeTool
    } // namespace Tools 
} // end namespace Custem
