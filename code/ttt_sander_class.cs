using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Classes;
using TerrorTown;
using Sandbox;
using Turrets_Items;

namespace TTT_Classes
{
	public class Sander : TTT_Class
	{

		public override string Name { get; set; } = "Sander";
		public override string Description { get; set; } = "Please avoid your teammates";
		public override float Frequency { get; set; } = 1f;

		public override Color Color { get; set; } = Color.FromRgb( 0xfc6603 );



		//Run on start
		public override void RoundStartAbility()
		{
			Add_Item_To_Player( new Turrets_Items.BigImpactGrenade() );
		}
	}
}
