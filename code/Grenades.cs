using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerrorTown;
using Sandbox.ModelEditor.Nodes;

namespace Turrets_Items
{

	[Title( "Frag Grenade " )]
	[Category( "Grenades" )]
	public class FragGrenade : Throwable, IGrenade, IRandomGrenade
	{
		public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";

		public override string WorldModelPath => "models/simplefraggrenade.vmdl";

		public override void Throw()
		{
			if ( Game.IsServer )
			{

				FragGrenadeThrown x = new FragGrenadeThrown();
				x.ThrowMe( Owner.AimRay.Forward, (TerrorTown.Player)Owner );
				x.Fuze = 5 - TimeSinceClicked.Relative;
			}
		}

	}

	public class FragGrenadeThrown : BasePhysics
	{
		TerrorTown.Player Thrower;

		public virtual float start_speed { get; set; } = 500f;
		public virtual float radius { get; set; } = 250f;
		public virtual float damage { get; set; } = 70f;
		public virtual float force { get; set; } = 20f;
		public RealTimeUntil Fuze;
		public void ThrowMe( Vector3 dir, TerrorTown.Player ply )
		{
			Thrower = ply;
			Position = ply.AimRay.Forward * 50 + ply.EyeLocalPosition + ply.Position;
			Velocity = dir * start_speed;
			PhysicsBody.DragEnabled = true;
			PhysicsBody.GravityScale = 0.7f;
			Fuze = 5;
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
			modelPropData.Health = 100;
			modelPropData.MinImpactDamageSpeed = float.MaxValue;
			return modelPropData;
		}
		

		[GameEvent.Tick.Server]
		public void Tick()
		{
			if ( Fuze )
			{
				Explode();
			}
		}

		private void Explode()
		{

			TerrorTown.ExplosionEntity Boom = new TerrorTown.ExplosionEntity {Position = Position, Radius = radius, Damage = damage, ForceScale = force	};
			Boom.Explode( null );
			this.Delete();
		}


	}
	[Title( "The TeamKiller" )]
	[Category( "Grenades" )]
	public class BigImpactGrenade : Throwable, IGrenade
	{
		public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";

		public override string WorldModelPath => "models/simplefraggrenade.vmdl";

		public override void Throw()
		{
			if ( Game.IsServer )
			{

				BigImpactGrenadeThrown x = new BigImpactGrenadeThrown();
				x.ThrowMe( Owner.AimRay.Forward, (TerrorTown.Player)Owner );
			}
		}

	}
	public class BigImpactGrenadeThrown : BasePhysics
	{
		TerrorTown.Player Thrower;

		public virtual float start_speed { get; set; } = 1000f;
		public virtual float radius { get; set; } = 800f;
		public virtual float damage { get; set; } = 200f;
		public virtual float force { get; set; } = 20f;
		public void ThrowMe( Vector3 dir, TerrorTown.Player ply )
		{
			Thrower = ply;
			Position = ply.AimRay.Forward * 50 + ply.EyeLocalPosition + ply.Position;
			Velocity = dir * start_speed;
			PhysicsBody.DragEnabled = true;
			PhysicsBody.GravityScale = 0.5f;
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
			modelPropData.Health = 100;
			modelPropData.MinImpactDamageSpeed = float.MaxValue;
			return modelPropData;
		}


		public override void Touch( Entity other )
		{
			if ( other != Thrower && other.Parent != Thrower )
			{
				Explode();
				Delete();
			}

		}

		private void Explode()
		{

			TerrorTown.ExplosionEntity Boom = new TerrorTown.ExplosionEntity { Position = Position, Radius = radius, Damage = damage };
			Boom.Explode( null );
			this.Delete();

		}


	}

	[Title( "Impact Grenade" )]
	[Category( "Grenades" )]
	[TraitorBuyable( "Weapons", 2, 0 )]
	public class ImpactGrenade : Throwable, IGrenade
	{
		public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";

		public override string WorldModelPath => "models/simplefraggrenade.vmdl";

		public override void Throw()
		{
			if ( Game.IsServer )
			{

				ImpactGrenadeThrown x = new ImpactGrenadeThrown();
				x.ThrowMe( Owner.AimRay.Forward, (TerrorTown.Player)Owner );
			}
		}

	}
	public class ImpactGrenadeThrown : BasePhysics
	{
		TerrorTown.Player Thrower;

		public virtual float start_speed { get; set; } = 1200f;
		public virtual float radius { get; set; } = 500f;
		public virtual float damage { get; set; } = 130f;
		public virtual float force { get; set; } = 20f;
		public void ThrowMe( Vector3 dir, TerrorTown.Player ply )
		{
			Thrower = ply;
			Position = ply.AimRay.Forward * 50 + ply.EyeLocalPosition + ply.Position;
			Velocity = dir * start_speed;
			PhysicsBody.DragEnabled = true;
			PhysicsBody.GravityScale = 0.5f;
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
			modelPropData.Health = 100;
			modelPropData.MinImpactDamageSpeed = float.MaxValue;
			return modelPropData;
		}


		public override void Touch( Entity other )
		{
			if ( other != Thrower && other.Parent != Thrower )
			{
				Explode();
				Delete();
			}

		}

		private void Explode()
		{

			TerrorTown.ExplosionEntity Boom = new TerrorTown.ExplosionEntity { Position = Position, Radius = radius, Damage = damage };
			Boom.Explode( null );
			this.Delete();

		}


	}
}

