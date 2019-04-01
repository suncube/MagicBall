using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalizationHelper : MonoBehaviour {

    public enum LocalizationType
    {
        English,
        Belarussian,
        Russian
    }

    public static LocalizationHelper instance;
    public Action OnChangeLocalization;
    private LocalizationType _localization = LocalizationType.English;// todo add save
    public LocalizationType Localization
    {
        get { return _localization; }
        set
        {
            _localization = value;
            PlayerPrefs.SetInt("localize", (int)_localization);
            if (OnChangeLocalization != null)
                OnChangeLocalization();
        }
    }


    private Dictionary<string, Dictionary<string, string>> localizationLibrary;
	// Use this for initialization
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        Initialize();
    }

    private void Initialize()
    {
        var english = new Dictionary<string, string>
        {
            {"theme0", "Classic"},
            {"theme1", "Temp"},
            {"back", "Back"},
            {"themes", "Balls"},
            {"game", "GO"},
            {"settings", "Settings"},
            {"menu", "Menu"},

            {"A1", "It is certain"},
             {"A2", "It is decidedly so"},
              {"A3", "Without a doubt"},
               {"A4", "Yes — definitely"},
                {"A5", "You may rely on it"},
                 {"A6", "As I see it, yes"},
                  {"A7", "Most likely"},
                   {"A8", "Outlook good"},
                    {"A9", "Signs point to yes"},
                     {"A10", "Yes"},
                      {"A11", "Reply hazy, try again"},
                       {"A12", "Ask again later"},
                        {"A13", "Better not tell you now"},
                         {"A14", "Cannot predict now"},
                          {"A15", "Concentrate and ask again"},
                           {"A16", "Don’t count on it"},
                            {"A17", "My reply is no"},
                             {"A18", "My sources say no"},
                              {"A19", "Outlook not so good"},
                               {"A20", "Very doubtful"}
        };
        var russian = new Dictionary<string, string>
        {
            {"theme0", "Классический"},
            {"theme1", "Тест"},
            {"back", "Назад"},
            {"themes", "Шары"},
            {"game", "Начать"},
            {"settings", "Свойства"},
            {"menu", "Меню"},

            {"A1", "Бесспорно"},
             {"A2", "Предрешено"},
              {"A3", "Никаких сомнений"},
               {"A4", "Определённо да"},
                {"A5", "Можешь быть уверен в этом"},
                 {"A6", "Мне кажется — «да»"},
                  {"A7", "Вероятнее всего"},
                   {"A8", "Хорошие перспективы"},
                    {"A9", "Знаки говорят — «да»"},
                     {"A10", "Да"},
                      {"A11", "Пока не ясно, попробуй снова"},
                       {"A12", "Спроси позже"},
                        {"A13", "Лучше не рассказывать"},
                         {"A14", "Сейчас нельзя предсказать"},
                          {"A15", "Сконцентрируйся и спроси опять"},
                           {"A16", "Даже не думай"},
                            {"A17", "Мой ответ — «нет»"},
                             {"A18", "По моим данным — «нет»"},
                              {"A19", "Перспективы не очень хорошие"},
                               {"A20", "Весьма сомнительно"}
        };
        var belarus = new Dictionary<string, string>
        {
            {"theme0", "Классический"},
            {"theme1", "Тест"},
            {"back", "Назад"},
            {"themes", "Шары"},
            {"game", "Начать"},
            {"settings", "Свойства"},
            {"menu", "Меню"},

            {"A1", "Бясспрэчна"},
             {"A2", "Перадвырашана"},
              {"A3", "Ніякіх сумневаў"},
               {"A4", "Вызначана да"},
                {"A5", "Можаш быць упэўнены ў гэтым"},
                 {"A6", "Мне здаецца - «так»"},
                  {"A7", "Верагодней за ўсё"},
                   {"A8", "Добрыя перспектывы"},
                    {"A9", "Знакі кажуць - «так»"},
                     {"A10", "Так"},
                      {"A11", "Пакуль не ясна, паспрабуй зноў"},
                       {"A12", "Спытай пазней"},
                        {"A13", "Лепш не распавядаць"},
                         {"A14", "Цяпер нельга прадказаць"},
                          {"A15", "Сканцэнтруйцеся і спытай зноў"},
                           {"A16", "Нават не думай"},
                            {"A17", "Мой адказ - «не»"},
                             {"A18", "Па маіх дадзеных - «не»"},
                              {"A19", "Перспектывы не вельмі добрыя"},
                               {"A20", "Вельмі сумнеўна"}
        };

        localizationLibrary = new Dictionary<string, Dictionary<string, string>>
        {
                    {"English",english},
                    {"Belarussian",belarus},
                    {"Russian", russian}
        };


        var i = PlayerPrefs.GetInt("localize");
        Localization = (LocalizationType) i;
    }


    public string GetTextByKey(string key)
    {
        if (string.IsNullOrEmpty(key)) return string.Empty;

        Dictionary<string, string> dictionary;
        if (localizationLibrary.TryGetValue(_localization.ToString(), out dictionary))
        {
            string result;
            if (dictionary.TryGetValue(key, out result))
                return result;
        }


        return key;
    }
}

