/*
Name: T'Kai Monet
Email: tmonet@student.cnm.edu
File Name: IdealGas.cs
Date: 2/16/2026
*/

/*
Name: t’kai monet
Email: your_email@email.com
File Name: Program.cs
Date: 2/16/2026
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        string[] gasNames = new string[10];
        double[] molecularWeights = new double[10];
        int count = 0;

        DisplayHeader();
        GetMolecularWeights(gasNames, molecularWeights, ref count);
        DisplayGasNames(gasNames, count);

        string again;

        do
        {
            try
            {
                Console.Write("Enter gas name: ");
                string gasName = Console.ReadLine();

                double mw = GetMolecularWeightFromName(gasNames, molecularWeights, count, gasName);

                if (mw == -1)
                {
                    Console.WriteLine("Gas not found.");
                }
                else
                {
                    IdealGas gas = new IdealGas();

                    Console.Write("Enter volume (m^3): ");
                    double volume = double.Parse(Console.ReadLine());

                    Console.Write("Enter mass (grams): ");
                    double mass = double.Parse(Console.ReadLine());

                    Console.Write("Enter temperature (Celsius): ");
                    double temp = double.Parse(Console.ReadLine());

                    gas.SetMolecularWeight(mw);
                    gas.SetVolume(volume);
                    gas.SetMass(mass);
                    gas.SetTemperature(temp);

                    DisplayPressure(gas.GetPressure(), temp);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input format error. Please enter valid numbers.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number too large or too small.");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: " + exc.Message);
            }

            Console.Write("Do another? (y/n): ");
            again = Console.ReadLine();

        } while (again.ToLower() == "y");

        Console.WriteLine("Goodbye!");
    }

    static void DisplayHeader()
    {
        Console.WriteLine("t’kai monet");
        Console.WriteLine("Ideal Gas Equation Program");
        Console.WriteLine("Objective: Calculate pressure using Ideal Gas Law\n");
    }

    static void GetMolecularWeights(string[] names, double[] weights, ref int count)
    {
        names[0] = "Oxygen";
        weights[0] = 32.00;

        names[1] = "Nitrogen";
        weights[1] = 28.02;

        names[2] = "Hydrogen";
        weights[2] = 2.02;

        count = 3;
    }

    static void DisplayGasNames(string[] names, int count)
    {
        Console.WriteLine("Available Gases:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(names[i]);
        }
        Console.WriteLine();
    }

    static double GetMolecularWeightFromName(string[] names, double[] weights, int count, string name)
    {
        for (int i = 0; i < count; i++)
        {
            if (names[i].ToLower() == name.ToLower())
            {
                return weights[i];
            }
        }
        return -1;
    }

    static void DisplayPressure(double pressure, double temp)
    {
        Console.WriteLine("Pressure: " + pressure + " Pascals");
        Console.WriteLine("Temperature: " + temp + " Celsius\n");
    }
}
