using System;
using System.Collections.Generic;

namespace No_2
{
    class SuperWaterer : Waterer
    {
        Dictionary<string, Waterer> waterAttitudes = new Dictionary<string, Waterer>();

        public SuperWaterer(Waterer low, Waterer common, Waterer strong)
        {
            waterAttitudes.Add("negative", low);
            waterAttitudes.Add("common", common);
            waterAttitudes.Add("positive", strong);
        }

        public virtual void ToWater(Flower flower)
        {
            Waterer choosenWaterer = ChooseWaterer(flower.waterAttitude);

            if (choosenWaterer != null)
            {
                choosenWaterer.ToWater(flower.flowerName);
            }
            else
            {
                Console.WriteLine($"Program error. '{flower.waterAttitude}' attitude to water does not exist");
            }
        }

        private Waterer ChooseWaterer(string waterAttitude)
        {
            Waterer choosenWaterer;

            waterAttitudes.TryGetValue(waterAttitude, out choosenWaterer);

            return choosenWaterer;
        }
    }
}
