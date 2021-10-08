using System;

namespace Lab_2
{
    class FillStation
    {
        public FillStation(RefuelingOperator oper)
        {
            IElectroCar[] eCars = new ElectroCar[2];
            eCars[0] = TeslaModelX.GetCar();
            eCars[1] = TeslaModelX.GetCar("Gregory", "OO0000OO", 100_000, 24_000);

            IICECar[] iceCars = new ICECar[2];
            iceCars[0] = MazdaMX5.GetCar();
            iceCars[1] = MazdaMX5.GetCar("StickMan", "JJ9999JJ", 40, 4);

            for (int i = 0; i < 2; i++)
            {
                oper.FillingEvent += new FillingHandle(eCars[i].ChargeCar);

                oper.FillingEvent += new FillingHandle(iceCars[i].FillCar);
            }
        }
    }
}
