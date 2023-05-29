

       using Menu;



        Console.WriteLine("0.Exit");
        Console.WriteLine("1.For Newton Interpolating Polynomial");
        Console.WriteLine("2.For Lagrange Interpolating Polynomial");
        Console.WriteLine("3.For Inverse Interpolating Polynomial");
        Console.WriteLine("4.For Spline Interpolating Polynomial");
        Console.WriteLine("6.For Linear Regression(straight line approximating");
        Console.WriteLine("7.For Linearization tecniques");
        Console.WriteLine("8.For Continuous Least Square");
        Console.WriteLine("9.For Monte-Carlo Integartion");
        Console.WriteLine("10.For Fourier Transform");
        Console.WriteLine("11.For Power Method");

        Console.WriteLine(" ");
        Console.Write("Your choice: ");
        string request = Console.ReadLine();
        Console.WriteLine(" ");


        while (request != "0")
        {
            switch (request)
            {
                case "1":
                    Methods.NewtonInterpolationMenu();
                    break;
                case "2":
                    Methods.LagrangeInterpolationMenu();
                    break;
                case "3":
                    Methods.InverseInterpolationMenu();
                    break;
                case "4":
                    Methods.SplineInterpolationMenu();
                    break;
                case "5":
                    break;
                case "6":
                    Methods.LinearRegressionMenu();
                    break;
                 case "7":
                    Methods.LinearizationTechniqueMenu();
                    break;
                 case "8":
                     Methods.ContinuousLeastSquareMenu();
                    break;
                  case "9":
                    Methods.MonteCarloAreaMenu();
                    break;
                 case "10":
                    Methods.FourierTransformMenu();
                    break;
                 case "11":
                    Methods.PowerMethodMenu();
                    break;
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.For Newton Interpolating Polynomial");
            Console.WriteLine("2.For Lagrange Interpolating Polynomial");
            Console.WriteLine("3.For Inverse Interpolating Polynomial");
            Console.WriteLine("4.For Spline Interpolating Polynomial");
            Console.WriteLine("6.For Linear Regression(straight line approximating");
            Console.WriteLine("7.For Linearization tecniques");
            Console.WriteLine("8.For Continuous Least Square");
            Console.WriteLine("9.For Monte-Carlo Integartion");
            Console.WriteLine("10.For Fourier Transform");
            Console.WriteLine("11.For Power Method");


            Console.WriteLine(" ");
            Console.Write("Your choice: ");
            request = Console.ReadLine();
            Console.WriteLine(" ");
        }





    