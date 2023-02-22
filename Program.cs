// This program opens Pilatus 100K image
//using System.Drawing;
// image dimensions
// number of rows in image
// image size in y direction
const int no_rows = 195;
// number of columns in image
// image_size in x direction
const int no_cols = 487;
// number of all pixels in image
int no_pixels = no_rows * no_cols;
// number of all bytes in image
// there are 4 bytes stored in each pixel
int no_bytes = no_pixels * 4;
// create integer array to store intensity values for each pixel
int[,] pixel_array = new int[no_pixels, 4];
// cretae flipped buffer for intensity values
int[,] pixel_array_flipped = new int[no_pixels, 4];
// path to image file
string path_to_image =@"d:\GIWAXS_measurements\2022\FarasUdDin\ITO_Mx_PSK\090222\ITO_Mx_PSK\090222_ITO_Mx_PSK_00001.tif";
FileStream my_stream = File.Open(path_to_image, FileMode.Open);
BinaryReader my_reader= new BinaryReader(my_stream);
// set offset position for header information; for Pilatus detectors, it is 4096 bytes by default
my_reader.BaseStream.Position=4096;
byte[] read_byte_array = my_reader.ReadBytes(no_bytes);
// store intensity values encoded in 4 bytes to each pixel
for (int index_0=0; index_0<no_pixels; index_0++)
{
    pixel_array[index_0, 0] = read_byte_array[4 * index_0];
    pixel_array[index_0, 1] = read_byte_array[4 * index_0 + 1];
    pixel_array[index_0, 2] = read_byte_array[4 * index_0 + 2];
    pixel_array[index_0, 3] = read_byte_array[4 * index_0 + 3];
}
// flip integer array of intensity values for each pixel
for (int index_0=0; index_0<no_pixels; index_0++)
{
    pixel_array_flipped[index_0, 0] = pixel_array[index_0, 3];
    pixel_array_flipped[index_0, 1] = pixel_array[index_0, 2];
    pixel_array_flipped[index_0, 2] = pixel_array[index_0, 1];
    pixel_array_flipped[index_0, 3] = pixel_array[index_0, 0];
}
// create string array for intensity values for each pixel
string[,] binary_array = new string[no_pixels,4];
// create dense string array for intensity values for each pixel
string[] binary_array_dense = new string[no_pixels];
// define divisor and remainder variables
int divisor;
int remainder;
int size_string;
int remaining_binary_digits;
// convert first byte to the binary string
for (int index_0=0; index_0<no_pixels; index_0++)
{
    divisor = pixel_array_flipped[index_0, 0];
    while (divisor > 0)
    {
        remainder = divisor % 2;
        divisor = divisor / 2;
        binary_array[index_0,0] = binary_array[index_0,0] + Convert.ToString(remainder);
    }
    if (binary_array[index_0, 0] == null)
    {
        binary_array[index_0, 0] = "00000000";
    }
    size_string = binary_array[index_0, 0].Length;
    remaining_binary_digits = 8 - size_string;
    for (int index_1 = 0; index_1 < remaining_binary_digits; index_1++)
    {
        binary_array[index_0, 0] = binary_array[index_0, 0] + "0";
    }
}
// convert second byte to the binary string
for (int index_0 = 0; index_0 < no_pixels; index_0++)
{
    divisor = pixel_array_flipped[index_0, 1];
    while (divisor > 0)
    {
        remainder = divisor % 2;
        divisor = divisor / 2;
        binary_array[index_0, 1] = binary_array[index_0, 1] + Convert.ToString(remainder);
    }
    if (binary_array[index_0, 1] == null)
    {
        binary_array[index_0, 1] = "00000000";
    }
    size_string = binary_array[index_0, 1].Length;
    remaining_binary_digits = 8 - size_string;
    for (int index_1 = 0; index_1 < remaining_binary_digits; index_1++)
    {
        binary_array[index_0, 1] = binary_array[index_0, 1] + "0";
    }
}
// convert third byte to the binary string
for (int index_0 = 0; index_0 < no_pixels; index_0++)
{
    divisor = pixel_array_flipped[index_0, 2];
    while (divisor > 0)
    {
        remainder = divisor % 2;
        divisor = divisor / 2;
        binary_array[index_0, 2] = binary_array[index_0, 2] + Convert.ToString(remainder);
    }
    if (binary_array[index_0, 2] == null)
    {
        binary_array[index_0, 2] = "00000000";
    }
    size_string = binary_array[index_0, 2].Length;
    remaining_binary_digits = 8 - size_string;
    for (int index_1 = 0; index_1 < remaining_binary_digits; index_1++)
    {
        binary_array[index_0, 2] = binary_array[index_0, 2] + "0";
    }
}
// convert fourth byte to the binary string
for (int index_0 = 0; index_0 < no_pixels; index_0++)
{
    divisor = pixel_array_flipped[index_0, 3];
    while (divisor > 0)
    {
        remainder = divisor % 2;
        divisor = divisor / 2;
        binary_array[index_0, 3] = binary_array[index_0, 3] + Convert.ToString(remainder);
    }
    if (binary_array[index_0, 3] == null)
    {
        binary_array[index_0, 3] = "00000000";
    }
    size_string = binary_array[index_0, 3].Length;
    remaining_binary_digits = 8 - size_string;
    for (int index_1 = 0; index_1 < remaining_binary_digits; index_1++)
    {
        binary_array[index_0, 3] = binary_array[index_0, 3] + "0";
    }
}
// fill dense string array for intensity values for each pixel
for (int index_0=0; index_0 < no_pixels; index_0++)
{
    binary_array_dense[index_0] = binary_array[index_0, 3];
    binary_array_dense[index_0] = binary_array_dense[index_0] + binary_array[index_0, 2];
    binary_array_dense[index_0] = binary_array_dense[index_0] + binary_array[index_0, 1];
    binary_array_dense[index_0] = binary_array_dense[index_0] + binary_array[index_0, 0];
}
// create integer array for intensity values
long[] intensity_array = new long[no_pixels];
// create single binary string variable
string single_binary_string;
// create single char variable
char single_char;
// convert binary strings to intensity values
for (int index_0=0; index_0 < no_pixels; index_0++)
{
    intensity_array[index_0] = 0;
    size_string = binary_array_dense[index_0].Length;
    single_binary_string = binary_array_dense[index_0];
    for (int index_1 = 0; index_1 < size_string; index_1++)
    {
        single_char = single_binary_string[index_1];
        if (single_char.Equals('0'))
        {
            intensity_array[index_0] = intensity_array[index_0] + 0 * (long)Math.Pow(2, index_1);
        } 
        else if (single_char.Equals('1'))
        {
            intensity_array[index_0] = intensity_array[index_0] + 1 * (long)Math.Pow(2, index_1);
        }
    }
}
//// print converted intensity values to the computer screen
//for (int index_0=0; index_0 < no_pixels; index_0++)
//{
//    Console.WriteLine(intensity_array[index_0]);
//}
// path to text file
string path_to_text_file = @"d:\C_sharp\Read_Pilatus100K_Image_ConsoleApp\experimental_text_file\exp_text_file.txt";
// create object StreamWriter
StreamWriter sw = new StreamWriter(path_to_text_file);
// write data
int counter = 0;
for (int index_0=0; index_0 < no_rows; index_0++)
{
    for (int index_1=0; index_1 < no_cols; index_1++)
    {
        sw.Write(intensity_array[counter] + "\t");
        counter++;
    }
    sw.Write("\n");
}
sw.Close();
////// save image as bitmap
//byte[] intensity_byte_array = new byte[intensity_array.Length];
//Buffer.BlockCopy(intensity_byte_array, 0, intensity_array, 0, no_pixels*sizeof(long));
//MemoryStream ms = new MemoryStream(intensity_byte_array);
//Bitmap image = new Bitmap(ms,true);
//image.Save(@"d:\GIWAXS_measurements\2022\FarasUdDin\ITO_Mx_PSK\090222\ITO_Mx_PSK\090222_ITO_Mx_PSK_00001.bmp");