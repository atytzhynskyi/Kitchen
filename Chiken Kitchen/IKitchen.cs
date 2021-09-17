namespace Chiken_Kitchen
{
    interface IKitchen
    {
        void Cook(Menu menu, Ingredient order);
        bool isEnoughIngredients(Menu menu, Ingredient food);
    }
}