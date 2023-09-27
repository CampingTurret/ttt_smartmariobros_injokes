using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Classes;

namespace TTT_Classes
{
	public class Seiichi : TTT_Class
	{

		public override string Name { get; set; } = "Seiichi";
		public override string Description { get; set; } = "Seiichi Hiiragi is a bullied student who gets transported to another world by a god who wants him to be a hero. He arrives in a forest, far from his classmates and civilization. He faces many dangers and hardships, but he also meets new friends and allies. He discovers a gun that can evolve him and give him amazing abilities. With this gun, he hopes to change his life and become a hero in the new world. But he also learns that the world is not as simple as he thought, and that there are secrets and mysteries waiting to be uncovered.";
		public override float Frequency { get; set; } = 0.3f;

		public override Color Color { get; set; } = Color.FromRgb( 0x634208 );



		//Run on start
		public override void RoundStartAbility()
		{
			Add_Item_To_Player( new Turrets_Items.MonkeyGun() );
		}
	}
}
