using System;

class PragueParking
{
    static string[] parkingGarage = new string[100];


    static void main(string[] args)
    {

        while (true)
        {
            ShowMenu();
            HandleMenuChoice();

        }

    }

    static void ShowMenu()
    {
        Console.WriteLine("Välkommen till Prague parking!\n");
        Console.WriteLine("1. Parkera fordon");
        Console.WriteLine("2. Hämta fordon");
        Console.WriteLine("3. Flytta fordon");
        Console.WriteLine("4. Sök efter fordon");
        Console.WriteLine("5. Visa enskild parkeringsplats");
        Console.WriteLine("6. Visa hela parkeringshuset");
        Console.WriteLine("7. Avsluta");
    }

    static void HandleMenuChoice()
    {

        switch (Console.ReadLine())
        {
            case "1":
                AddVehicle();
                break;

            case "2":
                RemoveVehicle();
                break;

            case "3":
                MoveVehicle();
                break;

            case "4":
                SearchVehicle();
                break;

            case 5":
                PrintParkingSpot();
                break;

            case "6":
                PrintAllParkingSpots();
                break;

            default:
                Console.WriteLine("ogiltig val");
                break;
        }




        static void AddVehicle()
        {
            Console.Write("ange fordonstyp car eller mc):");
            string vehicleType = GetInput("Ange fordonstyp (CAR eller MC):").ToUpper();
            string regNumber = GetInput("Ange registreringsnummer: ").ToUpper();

            Console.Write("ange registreringsnummer: ");

            if (vehicleType == "CAR" || vehicleType == "MC")

            {
                int freeSpot = FindFreeSpot(vehicleType);
                if (freeSpot != -1)
                {
                    ParkVehicle(freeSpot, vehicleType, regNumber);
                    Console.WriteLine($"{vehicleType} med registreringsnummer {regNumber} parkerades på plats {freeSpot + 1}");
                }
                else
                {
                    Console.WriteLine($"Inga lediga för {vehicleType}.");
                }

            }
            else
            {
                Console.WriteLine("Ogiltig fordonstyp");
            }
        }

        static void ParkVehicle(int spot, string vehicleType, string regNumber)
        {
            if (vehicleType == "MC" && parkingGarage[spot]?.StartsWith("MC#") == true)
            {
                parkingGarage[spot] += $"|MC# {regNumber}";
            }
            else
            {
                parkingGarage[spot] = $"{vehicleType}#{regNumber}";
            }
        }



        static int FindFreeSpot(string vehicleType)
        {
            for (int i = 0; i < parkingGarage.Length; i++)
            {
                if (vehicleType == "CAR" && parkingGarage[i] == null)
                    return i;

                if (vehicleType == "MC" && (parkingGarage[i] == null || (parkingGarage[i].StartsWith("MC#") && !parkingGarage[i].Contains("|"))))
                    return i;

            }
            return -1;
        }



    }
    static void MoveVehicle()
    {
        string regNumber = GetInput("Ange registreringsnummer på fordonet som ska flyttas:").ToUpper();
        int currentSpot = FindVehicle(regNumber);

        if (currentSpot != -1)
        {
            int newSpot = int.Parse(GetInput($"Ange ny plats för fordonet (tillfälligt på plats {currentSpot + 1}): ")) - 1;

            if (IsValidSpot(newSpot) && parkingGarage[newSpot] == null)
            {
                parkingGarage[newSpot] = parkingGarage[currentSpot];
                ClearSpot(currentSpot);
                Console.WriteLine($"Fordonet flyttades till plats {newSpot + 1}");
            }
            else
            {
                Console.WriteLine("Den nya platsen är antingen ogiltig eller upptagen.\n\n Vänligen försök igen.");
            }
        }
        else
        {
            Console.WriteLine("Fordonet hittades inte. \n\n Vänligen försök igen.");
        }

    }




    static void RemoveVehicle()
    {
        string regNumber = GetInput("Ange registreringsnummer på fordonet som ska hämtas: ").ToUpper();
        int spot = FindVehicle(regNumber);

        if (spot != -1)
        {
            if (parkingGarage[spot].Contains("|"))
            {
                parkingGarage[spot] = RemoveMCFromSpot(spot, regNumber);
            }
            else
            {
                ClearSpot(spot);
            }
            Console.WriteLine($"Fordonet med registreringsnummer {regNumber} togs bort från plats {spot + 1}. ");
        }
        else
        {
            Console.WriteLine("Fordonet hittades inte. \n Var vänligen försök igen.");
        }
    }

    static string RemoveMCFromSpot(int spot, string regNumber)
    {
        string[] Vehicles = parkingGarage[spot].Split('|');
        return string.Join("|", Array.FindAll(vehicles, v => !v.Contains(regNumber)));

    }


    static void ClearSpot(int spot)
    {
        parkingGarage[spot] = null;
    }

    static int FindVehicle(string regNumber)
    {
        for (int i = 0; i < parkingGarage.Length; i++)
        {
            if (parkingGarage[i]?.Contains(regNumber) == true)
                return i;
        }
        return -1;
    }

    static void SearchVehicle()
    {
        string regNumber = GetInput("")
    }


    static void PrintParkingSpot()
    {
        int spot = int.Parse(Get)
    }









































    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
}



