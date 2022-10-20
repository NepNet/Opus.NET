using System;

namespace Opus
{
	public class Decoder : IDisposable
	{
		public readonly IntPtr Handle;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sampleRate">Sample rate to decode at (Hz). This must be one of 8000, 12000, 16000, 24000, or 48000. </param>
		/// <param name="channels">Number of channels (1 or 2) to decode </param>
		/// <param name="error"></param>
		public Decoder(int sampleRate, int channels, out int error)
		{
			Handle = Imports.opus_decoder_create(sampleRate, channels, out error);
		}

		~Decoder()
		{
			Dispose();
		}

		/// <summary>
		/// Decode an Opus packet with floating point output. 
		/// </summary>
		/// <param name="data">Input payload. Use a NULL pointer to indicate packet loss </param>
		/// <param name="pcm">Output signal (interleaved if 2 channels). length is frame_size*channels*sizeof(float) </param>
		/// <param name="frameSize">Number of samples per channel of available space in pcm. If this is less than the maximum packet duration (120ms; 5760 for 48kHz), this function will not be capable of decoding some packets. In the case of PLC (data==NULL) or FEC (decode_fec=1), then frame_size needs to be exactly the duration of audio that is missing, otherwise the decoder will not be in the optimal state to decode the next incoming packet. For the PLC and FEC cases, frame_size must be a multiple of 2.5 ms.</param>
		/// <param name="flag">Flag to request that any in-band forward error correction data be decoded. If no such data is available the frame is decoded as if it were lost.</param>
		/// <returns></returns>
		[Obsolete]
		public int Decode(byte[] data, float[] pcm, int frameSize, bool flag = false)
		{
			return Imports.opus_decode_float(Handle, data, data.Length, pcm, frameSize, flag ? 1 : 0);
		}

		public void Dispose()
		{
			Imports.opus_decoder_destroy(Handle);
		}
	}
}