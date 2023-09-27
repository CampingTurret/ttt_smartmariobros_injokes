using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrorTown;

namespace Turrets_Audio
{
	public partial class ReaperSound
	{
		private static RealTimeUntil PlaySound;
		private static bool TimerSet = false; 

		[GameEvent.Tick.Server]
		public static void Tick()
		{
			Game.AssertServer();
			if (MyGame.Current.RoundState == RoundState.Started)
			{
				if ( !TimerSet )
				{
					PlaySound = MyGame.Current.PublicRoundLength - MyGame.Current.PublicRoundLength * Game.Random.Float( 0.1f, 0.7f ) * Game.Random.Float( 0.1f, 0.7f );
					TimerSet = true;
				}
				if ( PlaySound )
				{
					foreach ( IClient client in Game.Clients )
					{ 
						((TerrorTown.Player)client.Pawn).PlaySound( "reaper-leviathan-sounds-distant" );
					}
					PlaySound = 6000;
				}
			}
		}


		[Event( "Game.Round.Start" )]
		public static void OnRoundStart()
		{
			if ( Game.IsServer )
			{
				TimerSet = false;
				PlaySound = 10;
			}

		}

		[Event( "Game.Initialized" )]
		public static void Initialise_Sound( MyGame _game )
		{

		}
	}
}
