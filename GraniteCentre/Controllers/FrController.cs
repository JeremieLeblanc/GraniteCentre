using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteCentre.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using GraniteCentre.Helpers;

namespace GraniteCentre.Controllers
{
    public class FrController : Controller
    {
        public IActionResult Accueil()
        {
            return View();
        }

        [ActionName("Contactez-Nous")]
        public IActionResult ContactezNous()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
        }

        public IActionResult Chantier()
        {
            return View();
        }

        public IActionResult Detaillants()
        {
            return View();
        }

        [ActionName("Grand-Moncton")]
        public IActionResult GrandMoncton()
        {
            return View();
        }

        [ActionName("Analyse-Du-Detaillant")]
        public IActionResult AnalyseDuDetaillant()
        {
            return View();
        }

        public IActionResult Erreur()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ResponseModel> ContactForm(ContactModelFr data)
        {
            ResponseModel response = new ResponseModel() { };

            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Where(x => x.Value.ValidationState != ModelValidationState.Valid).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                response.Success = false;
                response.Data = JsonConvert.SerializeObject(errorList);
                response.Message = "Erreur de validation: Vous n'avez pas rempli les champs obligatoires ou vous ne les avez pas remplis correctement. S'il vous plaît faire des corrections où indiqué.";
                return response;
            }

            bool IsCaptchaValid = ReCaptchaClass.Validate(data.Captcha);

            if (IsCaptchaValid)
            {
                List<string> receiverAddresses = new List<string>() { "info@granitecentremoncton.com" };
                //List<string> receiverAddresses = new List<string>(){ "success@simulator.amazonses.com" };
                string htmlTemplate = "<div style='font-family:Arial, Helvetica, sans-serif'> <h3>Granite Centre Website Inquiry</h3> <p>Name: {{Name}}</p><p>Email: {{Email}}</p><p>Phone: {{Phone}}</p><br/> <p>Comments: </p><p>{{Comments}}</p><hr/> <img src='../images/Logo.png' style='width:200px; height:200px'/></div>";
                string textTemplate = "Granite Centre Website Inquiry\r\n\r\nName: {{Name}}\r\n\r\nEmail: {{Email}}\r\n\r\nPhone: {{Phone}}\r\n\r\n\r\n\r\nComments: \r\n\r\n{{Comments}}";

                string htmlBody = htmlTemplate.Replace("{{Name}}", data.Nom).Replace("{{Email}}", data.Email).Replace("{{Phone}}", data.Telephone).Replace("{{Comments}}", data.Commentaires);
                string textBody = textTemplate.Replace("{{Name}}", data.Nom).Replace("{{Email}}", data.Email).Replace("{{Phone}}", data.Telephone).Replace("{{Comments}}", data.Commentaires);

                ResponseModel result = await Helpers.Helpers.SendMailHelper(data.Email, receiverAddresses, "Granite Centre Website Inquiry by " + data.Nom, htmlBody, textBody);

                response.Success = result.Success;

                if (result.Success)
                {
                    response.Message = "Succès: Thank you, your inquiry has been received. One of our Granite Centre associates will be in touch shortly.";
                }
                else
                {
                    response.Message = "Erreur: Un erreur est survenue, veuillez réessayer plus tard.";
                }

                return response;
            }
            else
            {
                response.Success = false;
                response.Message = "S'il vous plaît remplir le ReCaptcha";

                return response;
            }
        }

        [HttpPost]
        public async Task<ResponseModel> RightFitForm(RightFitModelFr data)
        {
            ResponseModel response = new ResponseModel() { };

            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Where(x => x.Value.ValidationState != ModelValidationState.Valid).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                response.Success = false;
                response.Data = JsonConvert.SerializeObject(errorList);
                response.Message = "Validation error: You have not completed the mandatory fields or you have not completed them correctly. Please make corrections where indicated.";
                return response;
            }

            bool IsCaptchaValid = ReCaptchaClass.Validate(data.Captcha);

            if (IsCaptchaValid)
            {
                List<string> receiverAddresses = new List<string>() { "info@granitecentremoncton.com" };
                //List<string> receiverAddresses = new List<string>(){ "success@simulator.amazonses.com" };

                string answersHtmlTemplate = "<p><b>Question: </b>How are you creating a one-of-a-kind experience for customers?</p><p><b>Answer:</b>{{RightFit1}}</p><br /><p><b>Question: </b>What are you doing to create the surprise and delight that inspires customer attachment?</p><p><b>Answer:</b>{{RightFit2}}</p><br /><p><b>Question: </b>How are you using technology to accelerate self-discovery and individuality?</p><p><b>Answer:</b>{{RightFit3}}</p><br /><p><b>Question: </b>How is your store experience designed to encourage socialization and play before people buy?</p><p><b>Answer:</b>{{RightFit4}}</p><br /><p><b>Question: </b>How does your store serve as a showcase to drive online engagement?</p><p><b>Answer:</b>{{RightFit5}}</p><br /><p><b>Question: </b>What are you doing to make your customers feel like they’re part of a community?</p><p><b>Answer:</b>{{RightFit6}}</p><br /><p><b>Question: </b>How do you enrich your customer’s experience by gathering and integrating personal data?</p><p><b>Answer:</b>{{RightFit7}}</p><br /><p><b>Question: </b>What processes are you using to find new systems & technologies that empower people and simplify their lives?</p><p><b>Answer:</b>{{RightFit8}}</p><br />";
                string answersHtml = answersHtmlTemplate.Replace("{{RightFit1}}", data.RightFit1).Replace("{{RightFit2}}", data.RightFit2).Replace("{{RightFit3}}", data.RightFit3).Replace("{{RightFit4}}", data.RightFit4).Replace("{{RightFit5}}", data.RightFit5).Replace("{{RightFit6}}", data.RightFit6).Replace("{{RightFit7}}", data.RightFit7).Replace("{{RightFit8}}", data.RightFit8);
                string answersTextTemplate = "Question: How are you creating a one-of-a-kind experience for customers?\r\nAnswer:{{RightFit1}}\r\n\r\nQuestion: What are you doing to create the surprise and delight that inspires customer attachment?\r\nAnswer:{{RightFit2}}\r\n\r\nQuestion: How are you using technology to accelerate self-discovery and individuality?\r\nAnswer:{{RightFit3}}\r\n\r\nQuestion: How is your store experience designed to encourage socialization and play before people buy?\r\nAnswer:{{RightFit4}}\r\n\r\nQuestion: How does your store serve as a showcase to drive online engagement?\r\nAnswer:{{RightFit5}}\r\n\r\nQuestion: What are you doing to make your customers feel like they’re part of a community?\r\nAnswer:{{RightFit6}}\r\n\r\nQuestion: How do you enrich your customer’s experience by gathering and integrating personal data?\r\nAnswer:{{RightFit7}}\r\n\r\nQuestion: What processes are you using to find new systems & technologies that empower people and simplify their lives?\r\nAnswer:{{RightFit8}}\r\n\r\n";
                string answersText = answersTextTemplate.Replace("{{RightFit1}}", data.RightFit1).Replace("{{RightFit2}}", data.RightFit2).Replace("{{RightFit3}}", data.RightFit3).Replace("{{RightFit4}}", data.RightFit4).Replace("{{RightFit5}}", data.RightFit5).Replace("{{RightFit6}}", data.RightFit6).Replace("{{RightFit7}}", data.RightFit7).Replace("{{RightFit8}}", data.RightFit8);

                string htmlTemplate = "<div style='font-family:Arial, Helvetica, sans-serif'> <h3>Granite Centre Right Fit Analysis Response</h3> <p>Name: {{Name}}</p><p>Email: {{Email}}</p><p>Phone: {{Phone}}</p><br/> <p>Form: </p><p>{{Form}}</p><hr/> <img src='../images/Logo.png' style='width:200px; height:200px'/></div>";
                string textTemplate = "Granite Centre Right Fit Analysis Response\r\n\r\nName: {{Name}}\r\n\r\nEmail: {{Email}}\r\n\r\nPhone: {{Phone}}\r\n\r\n\r\n\r\nForm: \r\n\r\n{{Form}}";

                string htmlBody = htmlTemplate.Replace("{{Name}}", data.Nom).Replace("{{Email}}", data.Email).Replace("{{Phone}}", data.Telephone).Replace("{{Form}}", answersHtml);
                string textBody = textTemplate.Replace("{{Name}}", data.Nom).Replace("{{Email}}", data.Email).Replace("{{Phone}}", data.Telephone).Replace("{{Form}}", answersText);

                ResponseModel result = await Helpers.Helpers.SendMailHelper(data.Email, receiverAddresses, "Granite Centre RightFit Analysis Response by " + data.Nom, htmlBody, textBody);
                //ResponseModel result = new ResponseModel() { Success = true };

                response.Success = result.Success;

                if (result.Success)
                {
                    response.Message = "Succès: Thank you, your inquiry has been received. One of our Granite Centre associates will be in touch shortly.";
                }
                else
                {
                    response.Message = "Erreur: Un erreur est survenue, veuillez réessayer plus tard.";
                }

                return response;
            }
            else
            {
                response.Success = false;
                response.Message = "S'il vous plaît remplir le ReCaptcha";

                return response;
            }
        }
    }
}
