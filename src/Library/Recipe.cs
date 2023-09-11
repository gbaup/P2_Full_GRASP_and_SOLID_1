//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        /*
        SRP sugiere que una clase debe tener una única razón para cambiar, es decir, 
        debe tener una única responsabilidad. En este caso la responsabilidad asignada es 
        la de calcular el costo total.
        */
        public double GetProductionCost()
        {
            double insumosCost = 0;
            double equipamientoCost = 0;
            foreach (Step step in this.steps)
            {
                insumosCost += step.Input.UnitCost * step.Quantity;
                equipamientoCost += step.Equipment.HourlyCost * step.Time / 60;
            }
            double totalCost = insumosCost + equipamientoCost;

            return totalCost;
        }
    }
}