using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerrorTown;
using Sandbox.ModelEditor.Nodes;
using System.Numerics;


namespace Turrets_Items
{

	[Title("Venti")]
	[Category( "Grenades" )]
	[TraitorBuyable( "Throwables", 2, 0 )]
	public class venti_ult: Throwable
	{
		public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";

		public override string WorldModelPath => "models/simplefraggrenade.vmdl";

		public override void Throw()
		{
			if ( Game.IsServer )
			{

				VentiThrown x = new VentiThrown();
				x.ThrowMe( Owner.AimRay.Forward, (TerrorTown.Player)Owner );
				x.Fuze = 5 - TimeSinceClicked.Relative;
				Owner.PlaySound( "ventivoiceline" );
			}
		}
	}

	public class VentiThrown : BasePhysics
	{
		TerrorTown.Player Thrower;

		public virtual float start_speed { get; set; } = 800f;
		public virtual float radius { get; set; } = 320f;
		public virtual float damage { get; set; } = 5f;
		public virtual float force { get; set; } = -100f;
		public virtual float Duration { get; set; } = 10f;
		public RealTimeUntil Fuze;
		public RealTimeUntil Timer;
		public RealTimeUntil Destroy;
		private Particles particle;
		public void ThrowMe( Vector3 dir, TerrorTown.Player ply )
		{
			Thrower = ply;
			Position = ply.AimRay.Forward * 50 + ply.EyeLocalPosition + ply.Position;
			Velocity = dir * start_speed;
			PhysicsBody.DragEnabled = true;
			PhysicsBody.GravityScale = 0.7f;
			EnableDrawing = false;
			Fuze = 5f;
			Timer = 0.1f;
			Destroy = 5f + Duration;
			particle = Particles.Create( "tester_glow_green.vpcf", this );
		}
		public override void Spawn()
		{
			base.Spawn();
			SetModel( "models/simplefraggrenade.vmdl" );
		}
		protected override ModelPropData GetModelPropData()
		{
			ModelPropData modelPropData = base.GetModelPropData();
			modelPropData.ImpactDamage = 0;
			modelPropData.Health = 99990;
			modelPropData.MinImpactDamageSpeed = float.MaxValue;
			return modelPropData;
		}
		[GameEvent.Tick.Server]
		public void Tick()
		{
			if ( Fuze )
			{
				if (Timer)
				{
					Explode();
					Timer = 0.2f;
				}

				PhysicsBody.Enabled = false;
				
			}
			if ( Destroy )
			{
				this.Delete();
			}
		}

		private void Explode()
		{
			foreach ( Entity item in Sandbox.Entity.FindInSphere( Position, radius ) )
			{
				if ( item == this ) { continue; }
				Vector3 normal = (item.Position - Position).Normal;
				normal.z = Math.Abs( normal.z ) + 1f;
				item.Velocity -= normal * 256f;
				ModelEntity modelEntity = item as ModelEntity;
				if ( modelEntity != null )
				{
					modelEntity.PhysicsBody.Velocity -= normal * 50f;
				}
				if ( item is TerrorTown.Player )
				{
					item.TakeDamage( DamageInfo.FromExplosion( Position, 0, damage));
				}

			}
		

		}
	}
}
