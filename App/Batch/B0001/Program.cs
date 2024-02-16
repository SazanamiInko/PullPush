// See https://aka.ms/new-console-template for more information

using FLayer.APIs;

var response = API.LosdMituiFile();

if(!response.Success) return;