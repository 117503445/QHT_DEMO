#include <stdio.h>
#include <stdlib.h>

int i;// to present the menu onto the screen
int number_customer; // input the  Customer Number
int n = 0;// to control loop repeat times to equal to the customer number
int j;//control loop to print the receipt
char input_choice;// prompt the customer to input the dish number
char store_input[];
char input_feedback(char);


struct menu
{
	char number[10];
	char name[30];
	int price
};
struct menu dish[] =
{
"A1","HAM AND EGG",20,
"A2","BACON AND CHEESE",10,
"A3","TUNA SALAD",15,
"A4","BEEF SOUP",25,
"B1","SPICY BEEF BARBECUE",20,
"B2","PORK BARBECUE",10,
"B3","OVEN CHICKEN BARBECUE",15,
"B4","PULLED BEEF BARBECUE BURGER",25,
"C1","SPICY PORK BARBECUE",20,
"C2","VEGETABLE PORK BARBECUE",10,
"C3","OVEN PORK BARBECUE",15,
"C4","PULLED PORK BARBECUE",25
};   // create the menu dish
struct store_dish
{
	char number[50];
	char name[50];
	int  price
};
struct store_dish display[] = {};
struct store_dish* ptr_display;
int main()
{

	printf("\t\tWELCOME!!! THIS IS THE MENU!!!\n");
	printf("\t\t   BREAKFAST  (Available: 8 am - 10 am)\n");
	for (i = 0; i < 4; i++)
	{
		printf("\n\t%s\t%-30s\t\t$%d\n", dish[i].number, dish[i].name, dish[i].price);
	}
	printf("\n\t\t   LUNCH      (Available: 11 am - 1 pm)\n");
	for (i = 4; i < 8; i++)
	{
		printf("\n\t%s\t%-30s\t\t$%d\n", dish[i].number, dish[i].name, dish[i].price);
	}
	printf("\n\t\t   DINNER     (Available: 5 pm - 8 pm)\n");
	for (i = 8; i < 12; i++)
	{
		printf("\n\t%s\t%-30s\t\t$%d\n", dish[i].number, dish[i].name, dish[i].price);
	}   //Display the menu

	printf("\nPlease enter the number of customers:");
	while (scanf("%d", &number_customer) != 1)
	{
		printf("\nPlease enter the correct number!!!:");
		scanf("%d", &number_customer);
		fflush(stdin);
	}            //repeat until the customer enter number
	printf("\nPlease select your dishes(type 'F' or 'f' to quit):\n");//prompt the customer to input dish number

	while (n < number_customer)
	{
		printf("Please enter one favorite dish:\n");
		scanf("%s", &input_choice);
		while (input_choice != 'f' && input_choice != 'F')
		{
			input_feedback(input_choice);
			if (input_choice == *ptr_display->number)
			{
			}
			printf("enter another favorite dish:\n");
			scanf("%s", &input_choice);
			fflush(stdin);
		}
		n++;
		if ((input_choice == 'f' && n < number_customer) || (input_choice == 'F' && n < number_customer))
		{
			printf("Next one,please\n");
			continue;
		}//end one input move onto next customer
	}

	printf("----------------------------------------------------------------\n");
	printf("\n\t\tTHANK YOU FOR DINING HERE!!!\t\n");
	printf("\n----------------------------------------------------------------\n");
	printf("\t\t    Here is your receipt:\n"); //print the receipt
	for (j = 1; j <= number_customer; j++)
	{
		printf("\n\tCustomer%d:\n", j);
		printf("\t%s\t%s\t$%d\n", display.number, display.name, display.price);
		printf("\tCode Dish\t\t\tPrice");
	}
	return 0;
}
char input_feedback(char input_choice)
{
	int x = 0;
	struct menu* ptr_number;
	ptr_number = &dish[x];
	while (x < 13)
	{
		if (input_choice != *ptr_number->number)
		{
			ptr_number++;
			x++;
		}

	}
	printf("Sorry, This dish code does not exist!!!\n");


	return;

}



