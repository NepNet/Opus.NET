using System;

namespace Opus
{

	public class Encoder : IDisposable
	{
		public readonly IntPtr Handle;

		/// <summary>
		/// Allocates and initializes an encoder state. 
		/// </summary>
		/// <param name="sampleRate">Sampling rate of input signal (Hz) This must be one of 8000, 12000, 16000, 24000, or 48000. </param>
		/// <param name="channels">Number of channels (1 or 2) in input signal </param>
		/// <param name="application">Coding mode</param>
		/// <param name="error"></param>
		public Encoder(int sampleRate, int channels, Application application, out int error)
		{
			Handle = Imports.opus_encoder_create(sampleRate, channels, application, out error);
		}

		~Encoder()
		{
			Dispose();
		}

		/// <summary>
		/// Encodes an Opus frame from floating point input. 
		/// </summary>
		/// <param name="pcm">Input in float format (interleaved if 2 channels), with a normal range of +/-1.0. Samples with a range beyond +/-1.0 are supported but will be clipped by decoders using the integer API and should only be used if it is known that the far end supports extended dynamic range. length is frame_size*channels*sizeof(float)</param>
		/// <param name="frameSize">Number of samples per channel in the input signal. This must be an Opus frame size for the encoder's sampling rate. For example, at 48 kHz the permitted values are 120, 240, 480, 960, 1920, and 2880. Passing in a duration of less than 10 ms (480 samples at 48 kHz) will prevent the encoder from using the LPC or hybrid modes. </param>
		/// <param name="data">Output payload.</param>
		/// <returns></returns>
		[Obsolete]
		public int Encode(float[] pcm, int frameSize, byte[] data)
		{
			return Imports.opus_encode_float(Handle, pcm, frameSize, data, data.Length);
		}

		public void Dispose()
		{
			Imports.opus_encoder_destroy(Handle);
		}
	}
}