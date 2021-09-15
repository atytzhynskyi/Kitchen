namespace Chiken_Kitchen
{
    interface IKitchen
    {
        void Cook(Food order);
        bool isEnoughIngredients(Food food);
        void AddNewIngredient();
        void ShowAll();
    }
}