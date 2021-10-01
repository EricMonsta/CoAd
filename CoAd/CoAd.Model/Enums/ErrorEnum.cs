namespace CoAd.Model.Enums
{
    public enum ErrorEnum
    {
        // все ок
        None = 0,
        // неизвестная ошибка
        Unknown = 1,
        // объект не найден
        NoObject = 2,
        // объект не совпадает
        InvalidObject = 3,
        // магазин не найден
        StoreNotFound = 4
    }
}