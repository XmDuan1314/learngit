using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADV212Test
{
    class Register
    {
        //Direct Register
        public static readonly byte PixelRegAddr = 0x00;//Pixel FIFO access register
        public static readonly byte CodeRegAddr = 0x01;//Compressed code stream access register
        public static readonly byte ATTRRegAddr = 0x02;//Attribute FIFO access register
        public static readonly byte CMDSTARegAddr = 0x04;//Command stack
        public static readonly byte EIRQIERegAddr = 0x05;//External  interrupt enabled
        public static readonly byte EIRQFLGRegAddr = 0x06;//External interrupt flags
        public static readonly byte SWFLAGRegAddr = 0x07;//Software flag register
        public static readonly byte BUSMODERegAddr = 0x08;//Bus mode configuration register
        public static readonly byte MMODERegAddr = 0x09;//Miscellaneous mode register
        public static readonly byte StageRegAddr = 0x0A;//Staging register
        public static readonly byte IADDRRegAddr = 0x0B;//Indirect address register
        public static readonly byte IDATARegAddr = 0x0C;//Indirect data register
        public static readonly byte BootRegAddr = 0x0D;//Boot mode register
        public static readonly byte PLL_HIRegAddr = 0x0E;//PLL control register, high byte
        public static readonly byte PLL_LORegAddr = 0x0F;//PLL control register, low byte
        //指令
        public static readonly byte commandWrite = 0x00;//Write command
        public static readonly byte commandRead = 0x80;//Read command
        public static readonly byte zeroFill = 0x00;//补零
        //Register Value
        //Enable EIRQIE[1] and EIRQIE[10]  0x0005
        public static readonly byte EIRQIERegValueH = 0x04;
        public static readonly byte EIRQIERegValueL = 0x02;
        //CLEAR FLAGS: EIRQFLG = 0xFFFF TO BEGIN ENCODING
        public static readonly byte EIRQFLGRegValueH = 0xFF;
        public static readonly byte EIRQFLGRegValueL = 0xFF;
        /// <summary>
        /// Set BusMode   0x0008
        /// </summary>
        public static readonly byte BUSMODERegValueH = 0x00;
        public static readonly byte BUSMODERegValueL = 0x05;
        /// <summary>
        /// Set MMode  0x0009
        /// </summary>
        public static readonly byte MMODERegValueH = 0x00;
        public static readonly byte MMODERegValueL = 0x05;
        /// <summary>
        /// Stage  0x000A
        /// </summary>
        //Load Firmware
        public static readonly byte StageRegLoadFirmwareValueH = 0x00;
        public static readonly byte StageRegLoadFirmwareValueL = 0x05;
        //Set Encode
        public static readonly byte StageRegSetEncodeValueH = 0x00;
        public static readonly byte StageRegSetEncodeValueL = 0x05;
        //Set Threshold = 64words
        public static readonly byte StageRegSetThreshold64ValueH = 0xFF;
        public static readonly byte StageRegSetThreshold64ValueL = 0xFF;
        //Set IndirectRegisterValues
        public static readonly byte StageRegSetIndirectRegisterValuePMODE11 = 0xFF;
        public static readonly byte StageRegSetIndirectRegisterValuePMODE12 = 0xFF;
        public static readonly byte StageRegSetIndirectRegisterValuePMODE13 = 0x04;
        public static readonly byte StageRegSetIndirectRegisterValuePMODE14 = 0x00;

        public static readonly byte StageRegSetIndirectRegisterValueXTOT1 = 0xFF;
        public static readonly byte StageRegSetIndirectRegisterValueXTOT2 = 0xFF;
        public static readonly byte StageRegSetIndirectRegisterValueXTOT3 = 0x04;
        public static readonly byte StageRegSetIndirectRegisterValueXTOT4 = 0x0C;

        public static readonly byte StageRegSetIndirectRegisterValuePMODE21 = 0xFF;
        public static readonly byte StageRegSetIndirectRegisterValuePMODE22 = 0xFF;
        public static readonly byte StageRegSetIndirectRegisterValuePMODE23 = 0x04;
        public static readonly byte StageRegSetIndirectRegisterValuePMODE24 = 0x48;
        /// <summary>
        /// IADDR  0x000B
        /// </summary>
        //Load Firmware
        public static readonly byte IADDRRegLoadFirmwareValueH = 0x00;
        public static readonly byte IADDRRegLoadFirmwareValueL = 0x00;
        //Set Encode
        public static readonly byte IADDRRegSetEncodeValueH = 0x7F;
        public static readonly byte IADDRRegSetEncodeValueL = 0x00;
        //Set Threshold = 64words
        public static readonly byte IADDRRegSetThreshold64ValueH = 0x14;
        public static readonly byte IADDRRegSetThreshold64ValueL = 0x1C;
        /// <summary>
        /// IDATA  0x000C
        /// </summary>
        //Set Threshold = 64words
        public static readonly byte IDATARegSetThreshold64ValueH = 0x00;
        public static readonly byte IDATARegSetThreshold64ValueL = 0x40;
        /// <summary>
        /// Enter BootMode 0x000D
        /// </summary>
        //Enter No-Host Boot Mode
        public static readonly byte BootRegNoHostBootValueH = 0x00;
        public static readonly byte BootRegNoHostBootValueL = 0x8A;
        //Soft Reboot
        public static readonly byte BootRegSoftReBootValueH = 0x00;
        public static readonly byte BootRegSoftReBootValueL = 0x8D;
        //Set internal clocks  0x000E,0x000F
        public static readonly byte PLL_HIRegValueH = 0x00;
        public static readonly byte PLL_HIRegValueL = 0x08;
        public static readonly byte PLL_LORegValueH = 0x00;
        public static readonly byte PLL_LORegValueL = 0x04;
    }
}