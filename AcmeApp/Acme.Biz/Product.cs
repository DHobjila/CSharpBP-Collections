﻿using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            #region Working with Arrays
            ////var colorOptions = new string[4];
            ////colorOptions[0] = "Dragos";
            ////colorOptions[1] = "Claudiu";
            ////colorOptions[2] = "Senik";
            ////colorOptions[3] = "Justin";

            //string[] colorOptions = { "Dragos", "Claudiu", "Senik", "Justin" };

            ////Array methods
            //var seeIndex = Array.IndexOf(colorOptions, "Claudiu");
            //colorOptions.SetValue("Luci", 2);

            ////looping through an Array
            //for (int i = 0; i < colorOptions.Length; i++)
            //{
            //    colorOptions[i] = colorOptions[i].ToLower();
            //}

            //foreach (var item in colorOptions)
            //{
            //    Console.WriteLine($"Name is: {item}");
            //}

            //Console.WriteLine(colorOptions[0]);
            //=======================================================================
            #endregion
            #region Working with Lists
            //var nameList = new List<string>();
            //nameList.Add("Dragos");
            //nameList.Add("Claudiu");
            //nameList.Add("Luci");
            //nameList.Add("Senik");
            //nameList.Insert(2, "Justin");
            //nameList.Remove("Senik");


            //var nameList = new List<string> { "Dragos", "Claudiu", "Justin", "Senik", "Luci" };

            //Console.WriteLine(nameList);
            #endregion

            #region Working with Dictionaries

            //var states = new Dictionary<string, string>();
            //states.Add("BT", "Botosani");
            //states.Add("B", "Bucuresti");
            //states.Add("BV", "Brasov");

            // Initializing a dictionary
            var states = new Dictionary<string, string>()
            {
                {"BT", "Botosani" },
                {"B", "Bucuresti"},
                {"BV", "Brasov" }
            };

            Console.WriteLine(states);



            #endregion

        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult <decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";
            if (markupPercent <= 0)
            {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }

            var value = this.Cost + (this.Cost * markupPercent / 100);
            var operationalResult = new OperationResult <decimal> (value, message);
            return operationalResult;
        }    

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
