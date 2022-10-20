using System;
using System.Runtime.InteropServices;

namespace Opus
{
	internal static class Imports
	{
		private const string LIB_NAME = "libopus.so";

		[DllImport(LIB_NAME)]
		internal static extern IntPtr opus_encoder_create(
			int Fs,
			int channels,
			Application application,
			out int error);

		[DllImport(LIB_NAME)]
		internal static extern IntPtr opus_decoder_create(
			int Fs,
			int channels,
			out int error
		);

		[DllImport(LIB_NAME)]
		internal static extern void opus_encoder_destroy(IntPtr encoder);

		[DllImport(LIB_NAME)]
		internal static extern void opus_decoder_destroy(IntPtr decoder);


		[DllImport(LIB_NAME)]
		internal static extern int opus_encode_float(
			IntPtr st,
			float[] pcm,
			int frame_size,
			[Out] byte[] data,
			int max_data_bytes);

		[DllImport(LIB_NAME)]
		internal static extern int opus_decode_float(IntPtr st,
			byte[] data,
			int len,
			[Out] float[] pcm,
			int frame_size,
			int decode_fec
		);
	}
}