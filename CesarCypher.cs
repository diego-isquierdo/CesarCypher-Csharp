using System;
using System.Text.RegularExpressions;

public class CesarCypher : ICrypt, IDecrypt
{
	private static byte casas = 3;

	
    public String Crypt(String texto) 
    {
        return GerarTextoCriptografia(texto, true);
    }


    public String Decrypt(String texto) 
    {
        return GerarTextoCriptografia(texto, false);
    }

	
	
    public String GerarTextoCriptografia(String texto, bool criptografar) 
    {
        
        String textoProcessado = String.Empty;
        int caracter=0;
		
		if(texto == String.Empty) return textoProcessado;
		if(texto == null) throw new ArgumentNullException();
				
        texto = texto.ToLower();
        for (int i = 0; i < texto.Length; i++) 
        {
            if ((texto[i] >= 'a') && (texto[i] <= 'z')) 
            {
                caracter = criptografar ? texto[i] + casas : texto[i] - casas;
				
				if(caracter < 97) caracter = caracter + 26;
				else if(caracter > 122) caracter = caracter -26;
				
                textoProcessado = String.Concat(textoProcessado,(char) caracter);
            } else {
				if(texto[i] >= 200) throw new ArgumentOutOfRangeException();
                textoProcessado = String.Concat(textoProcessado,texto[i]);
            }
        }

        return textoProcessado;
    }
	
}
