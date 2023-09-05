using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Classes;
using TerrorTown;
using Sandbox;

namespace TTT_Classes
{
	/*
    public partial class Anime_Girl_Class : TTT_Class
    {

        public override string Name { get; set; } = "Roy";
        public override string Description { get; set; } = "You are an anime girl";
        public override float Frequency { get; set; } = 0f;

        public override Color Color { get; set; } = Color.FromRgb(0x33ff00);



        //Run on start
        public override void RoundStartAbility()
        {

			foreach ( Clothing c in new List<Clothing>( Entity.Clothing.Clothing ) )
			{
				Entity.Clothing.Toggle( c );
			}

			//Entity.SetModel("models/nekomata_okayu/nekomata_okayu.vmdl");
			//Entity.OnNewModel(Entity.Model);

			AnimationGraph animationGraph = Entity.AnimGraph;


			
			
            Entity.Clothing.DressEntity(Entity);
			Entity.AnimGraph = animationGraph;
            Draw_clothes(Entity.Name);  
			
      


        }

        [ClientRpc]
        public static void Draw_clothes(string playername)
        {
            if (((TerrorTown.Player)Game.LocalPawn).Name == playername)
            {


                TerrorTown.Player ply = (TerrorTown.Player)Game.LocalPawn;
                ply.PlayerLegs.Delete();
                foreach (Clothing c in new List<Clothing>(ply.Clothing.Clothing))
                {
                    ply.Clothing.Toggle(c);
                }
                ply.Clothing.Toggle(get_clothing());
                ply.Clothing.DressEntity(ply);
				ply.CreateLegs();
                foreach (Entity child in ply.PlayerLegs.Children)
                {
                    if (child.Tags.Has("clothes"))
                    {
                        ((ModelEntity)child).EnableDrawing = false;
                        ((ModelEntity)child).EnableViewmodelRendering = false;

                        if (((ModelEntity)child).GetModelName() == get_clothing().Model)
                        {
                            ((ModelEntity)child).EnableDrawing = true;
                            ((ModelEntity)child).EnableViewmodelRendering = false;
                        }

                    }
                }
            }
        }

        public static Clothing get_clothing()
        {
            Clothing clothing = new Clothing();
            clothing.Model = "";
            clothing.SlotsOver = Clothing.Slots.Skin;
            clothing.Category = Clothing.ClothingCategory.Skin;

            return clothing;
        }
    }

	*/
}

