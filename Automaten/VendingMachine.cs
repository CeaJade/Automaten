using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
	class VendingMachine
	{
		private bool isFull;
		public ProductHolder[] productHolders;
		public MoneyBox moneyBox;
		public int availableSlots;
		public int coinCount;
		public int selectedItem;

		//Gets information of whether the new vending machine is full or empty
		public bool IsFull
		{
			get { return isFull; }
			set { isFull = value; }
		}
		

		public VendingMachine(bool isFull, int availableSlotsForEveryProduct)
		{
			this.IsFull = isFull;
			this.availableSlots = availableSlotsForEveryProduct;

			productHolders = new ProductHolder[]
			{
				new ProductHolder(availableSlots),
				new ProductHolder(availableSlots),
				new ProductHolder(availableSlots),
				new ProductHolder(availableSlots),
			};
			if (isFull)
			{
				for(int i = 0; i < availableSlots; i++)
				{
					productHolders[0].AddProduct(new Product("Soda", 2));
				}
				for (int i = 0; i < availableSlots; i++)
				{
					productHolders[1].AddProduct(new Product("Water", 1));
				}
				for (int i = 0; i < availableSlots; i++)
				{
					productHolders[2].AddProduct(new Product("Chocolate", 5));
				}
				for (int i = 0; i < availableSlots; i++)
				{
					productHolders[3].AddProduct(new Product("Chips", 3));
				}
			}

			this.moneyBox = new MoneyBox();
		}


		public void InsertCoins(int coins)
		{
			this.coinCount += coins;
		}


		public ProductHolder GetSelectedProduct()
		{
			return this.productHolders[this.selectedItem];
		}


		public Product DispenseProduct()
		{
			return this.productHolders[this.selectedItem].GetProduct();
		}


		public int DispenseCoin(bool soldProduct = true)
		{
			int change;
			if (soldProduct)
			{
				this.moneyBox.AddMoney(this.productHolders[this.selectedItem].PeekProduct().Price);
				change = this.coinCount - this.productHolders[this.selectedItem].PeekProduct().Price;
			} else
			{
				change = this.coinCount;
			}
			this.coinCount = 0;
			return change;
		}
	}
}
