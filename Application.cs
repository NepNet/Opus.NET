namespace Opus
{
	public enum Application
	{
		//Best for most VoIP/videoconference applications where listening quality and intelligibility matter most
		Voip = 2048,

		//Best for broadcast/high-fidelity application where the decoded audio should be as close as possible to the input
		Audio = 2049,

		//Only use when lowest-achievable latency is what matters most. Voice-optimized modes cannot be used.
		RestrictedLowDelay = 2051
	}
}