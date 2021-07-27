using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infra.Helpers
{
    public static class Validators
    {
        const string locale = "pt-BR";

        /// <summary>
        /// Valida CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsCpf(this string cpf)
        {
            string valor = cpf.Replace(".", "").Replace("-", "");

            if (!valor.IsNumber())
                return false;

            if (valor.Length != 11)
                return false;

            switch (valor)
            {
                case "00000000000":
                case "11111111111":
                case "22222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
            }

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;
            if (igual)
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        /// <summary>
        /// Validar CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool IsCnpj(this string cnpj)
        {
            string CNPJ = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            if (!CNPJ.IsNumber())
                return false;

            if (CNPJ.Length != 14)
                return false;

            switch (CNPJ)
            {
                case "00000000000000":
                case "11111111111111":
                case "22222222222222":
                case "33333333333333":
                case "44444444444444":
                case "55555555555555":
                case "66666666666666":
                case "77777777777777":
                case "88888888888888":
                case "99999999999999":
                    return false;
            }

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch { return false; }
        }

        /// <summary>
        /// Valida se a string de entrada é número
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsNumber(this string Value)
        {
            var result = decimal.TryParse(Value, out decimal number);
            return result;
        }

        /// <summary>
        /// Valida se a string de entrada é uma data
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string value)
        {
            var culture = CultureInfo.CreateSpecificCulture(locale);
            var styles = DateTimeStyles.AssumeLocal;
            var result = (DateTime.TryParse(value, culture, styles, out DateTime datetime));
            return result;
        }

        /// <summary>
        /// Valida se a string de entrada é um horario
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsTime(this string value)
        {
            var culture = CultureInfo.CreateSpecificCulture(locale);
            var styles = DateTimeStyles.AssumeLocal;
            var result = (DateTime.TryParse("01/01/2000 " + value, culture, styles, out DateTime datetime));
            return result;
        }

        public static bool OlderThan(this string finalDateStr, string initialDateStr)
        {
            if (!initialDateStr.IsDateTime())
                return false;

            if (!finalDateStr.IsDateTime())
                return false;

            var initialDate = Convert.ToDateTime(initialDateStr);
            var finalDate = Convert.ToDateTime(finalDateStr);

            return initialDate <= finalDate;
        }

        public static bool IsEmail(this string value)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
