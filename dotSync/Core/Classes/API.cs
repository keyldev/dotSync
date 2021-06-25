using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sharpSync.Core.Classes
{
    static class API
    {
        //  путь к серверному API
        const string SERVER_URL = "https://your_url_here.project";
        // регистрациноные константы
        const string REG_URL = "registration.php?";
        const string REG_NAME = "name=";
        const string REG_SURNAME = "surname=";
        const string REG_IP = "reg_ip=";
        // строковые параметры
        const string STRING_LOGIN = "login=";
        const string STRING_EMAIL = "email=";
        const string STRING_PASSWORD = "password=";

        // логин константа
        const string LOGIN_URL = "login.php?";
        const string LOGIN_IP = "last_ip=";
        // получить инфу аккаунта
        const string ACCOUNT_INFO_URL = "acc_info.php?";

        // баг репорт
        const string BUG_URL = "bugReport.php?";
        const string BUG_NAME = "name=";
        const string BUG_TOPIC = "topic=";
        const string BUG_TEXT = "bugtext=";
        const string BUG_TEST_NAME = "mike";

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="login">Логин</param>
        /// <param name="email">Почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="reg_ip">IP адрес для безопасности</param>
        /// <returns></returns>
        public static async Task<bool> regUser(string name, string surname, string login, string email, string password, string reg_ip)
        {
            var httpClient = new HttpClient();
            var requestUrl = SERVER_URL + REG_URL + REG_NAME + name + "&" + REG_SURNAME + surname + "&" + STRING_LOGIN + login + "&" 
                + STRING_EMAIL + email + "&" + STRING_PASSWORD + password + "&" + REG_IP + reg_ip;
            var response = await httpClient.PostAsync(new Uri(requestUrl), null);
            if (response.Content != null)
            {
                string textMessage = await response.Content.ReadAsStringAsync();
                if (textMessage.Equals("Yes"))
                {
                    httpClient.Dispose();
                    return true;
                }
                else
                {
                    httpClient.Dispose();
                    return false;
                }
            }
            else
            {
                httpClient.Dispose();
                return false;
            }
        }
        /// <summary>
        /// Форма отправки бага
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="topic">Тема бага</param>
        /// <param name="bugtext">Описание</param>
        /// <returns></returns>
        public static async Task<bool> reportBug(string username, string topic, string bugtext)
        {
            var httpClient = new HttpClient();
            var requestUrl = SERVER_URL + BUG_URL + BUG_NAME + username + "&" + BUG_TOPIC + topic + "&" + BUG_TEXT + bugtext;
            var response = await httpClient.PostAsync(new Uri(requestUrl), null);
            if (response.Content != null)
            {
                string textMessage = await response.Content.ReadAsStringAsync();
                if (textMessage.Equals("Yes"))
                {
                    httpClient.Dispose();
                    return true;
                }
                else
                {
                    httpClient.Dispose();
                    return false;
                }
            }
            else
            {
                httpClient.Dispose();
                return false;
            }

        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <param name="last_ip">получение нынешнего айпи пользователя</param>
        /// <returns></returns>
        public static async Task<bool> logUser(string login, string password, string last_ip)
        {
            var httpClient = new HttpClient();
            var requestUrl = SERVER_URL + LOGIN_URL + STRING_LOGIN + login + "&" + STRING_PASSWORD + password + "&" + LOGIN_IP + last_ip;
            var response = await httpClient.PostAsync(new Uri(requestUrl), null);

            if (response.Content != null)
            {
                string textMessage = await response.Content.ReadAsStringAsync();
                if (textMessage.Contains("Yes"))
                {
                    httpClient.Dispose();
                    return true;
                }
                else
                {
                    httpClient.Dispose();
                    return false;
                }
            }
            else
            {
                httpClient.Dispose();
                return false;
            }

        }
        /// <summary>
        /// Получить информацию о пользователе по логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static async Task<string[]> getInfo(string login)
        {
            var httpClient = new HttpClient();
            var requestUrl = SERVER_URL + ACCOUNT_INFO_URL + STRING_LOGIN + login;
            var response = await httpClient.PostAsync(new Uri(requestUrl), null);

            //var response = await httpClient.GetAsync(requestUrl);
            if (response.Content != null)
            {

                User test;
                string[] arr = new string[5];
                string textmessage = await response.Content.ReadAsStringAsync();
                test = JsonConvert.DeserializeObject<User>(textmessage);
                arr[0] = test.name;
                arr[1] = test.surname;
                arr[2] = test.login;
                arr[3] = test.email;
                arr[5] = test.last_seen;

                return arr;

            }
            else
            {
                httpClient.Dispose();
                return null;
            }
        }


    }
}
