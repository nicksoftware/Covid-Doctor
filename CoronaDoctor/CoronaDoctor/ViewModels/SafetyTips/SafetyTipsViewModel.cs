using CoronaDoctor.Models.SafetyTips;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaDoctor.ViewModels.SafetyTips
{
    class SafetyTipsViewModel
    {
        private const string Url = "https://images.unsplash.com/photo-1583324113626-70df0f4deaab?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=889&q=80";

        public List<SafetyTip> safetyTips { get; set; }
       
     
        public SafetyTipsViewModel()
        {
            safetyTips = new List<SafetyTip>()
            {
                new SafetyTip(){Title="How do you know if you are infected ?", 
                ImageUrl = "https://images.unsplash.com/photo-1583946099379-f9c9cb8bc030?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80",
                    Body = "The new Coronavirus may not show sign of infection for many days. How can one know if he/she is infected? By the time they have fever and/or cough and go to the hospital, the lung is usually 50% Fibrosis and it's too late. Taiwan experts provide a simple self-check that we can do every morning. Take a deep breath and hold your breath for more than 10 seconds. If you complete it successfully without coughing, without discomfort, stiffness or tightness, etc., it proves there is no Fibrosis in the lungs, basically indicates no infection. In critical time, please self-check every morning in an environment with clean air. Serious excellent advice by Japanese doctors treating COVID-19 cases: Everyone should ensure your mouth & throat are moist, never dry. Take a few sips of water every 15 minutes at least. Why? Even if the virus gets into your mouth, drinking water or other liquids will wash them down through your throat and into the stomach. Once there, your stomach acid will kill all the virus. If you don't drink enough water more regularly, the virus can enter your windpipe and into the lungs. That's very dangerous. Here are some new interesting findings about the corona virus.",
                SafetySteps = new List<SafetyStep>
                {
                    new SafetyStep{ Title = "Having a running nose ?", Body = " If you have a runny nose and sputum, you have a common cold"},
                    new SafetyStep{ Title = "1", Body = "Coronavirus pneumonia is a dry cough with no runny nose."},
                    new SafetyStep{ Title= "2" , Body = "This new virus is not heat-resistant and will be killed by a temperature of just 26/27 degrees. It hates the Sun"},
                    new SafetyStep{Title = "3", Body = "If someone sneezes with it, it takes about 10 feet before it drops to the ground and is no longer airborne. "},
                    new SafetyStep{ Title = "4",Body = "If it drops on a metal surface it will live for at least 12 hours - so if you come into contact with any metal surface - wash your hands as soon as you can with a bacterial soap. "},
                    new SafetyStep{ Title = "5", Body = "On fabric it can survive for 6-12 hours. normal laundry detergent will kill it."},
                    new SafetyStep{ Title = "6", Body = " Drinking warm water is effective for all viruses. Try not to drink liquids with ice."},
                    new SafetyStep{ Title = "7", Body = "Wash your hands frequently as the virus can only live on your hands for 5-10 minutes, but - a lot can happen during that time - you can rub your eyes, pick your nose unwittingly and so on. 9. You should also gargle as a prevention. A simple solution of salt in warm water will suffice. "},
                    new SafetyStep{ Title = "8", Body = "Can't emphasis enough - drink plenty of water! THE SYMPTOMS 1. It will first infect the throat, so you'll have a sore throat lasting 3/4 days 2. The virus then blends into a nasal fluid that enters the trachea and then the lungs, causing pneumonia. This takes about 5/6 days further. 3. With the pneumonia comes high fever and difficulty in breathing. 4. The nasal congestion is not like the normal kind. You feel like you're drowning. It's imperative you then seek immediate attention."}
                }
                },
               
                new SafetyTip() { Title = "When and how to wash hands ?",ImageUrl="https://images.unsplash.com/photo-1579544758011-951ee066f612?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=581&q=80",
                    Body = "Wash your hands often with soap and water for at least 20 seconds, especially after going to the bathroom; before eating; and after blowing your nose, coughing or sneezing. If soap and water are not readily available, use an alcohol-based hand sanitizer with at least 60% alcohol. Always wash hands with soap and water if hands are visibly dirty." },
                new SafetyTip() { Title = "Are you coughing ?",  ImageUrl="https://images.unsplash.com/photo-1581769060592-4008c031d332?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80",
                    Body = "Don't cough on your Hands,Cover your nose and mouth with a tissue when coughing or sneezing, and throw the tissue away after use. If a tissue isn’t available, cough or sneeze into your elbow or sleeve, not your hands." },
                new SafetyTip() { Title = "How to Keep clean.",ImageUrl="https://images.unsplash.com/photo-1580492516497-3c86977a6137?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80" ,Body = "Clean and disinfect doorknobs, switches, handles, computers, telephones, bedside tables, bathroom sinks, toilets, counters, toys and other surfaces that are commonly touched around the home or workplace." },
                new SafetyTip() { Title = "Are you going out ?",ImageUrl="https://images.unsplash.com/photo-1583519016318-bea9401059fd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80" ,Body = "Avoid touching public surfaces,To the extent possible, avoid touching commonly used surfaces in public places like elevator buttons, door handles and handrails and avoid handshaking with people. Use a tissue or your sleeve to cover your hand or finger if you must touch something." },
                new SafetyTip() { Title = "When to wear a mask?",ImageUrl="https://images.unsplash.com/photo-1583072248822-f909497b6ab6?ixlib=rb-1.2.1&auto=format&fit=crop&w=750&q=80",
                    Body = "Facemasks should be used by people who show symptoms of COVID-19 to help prevent the spread of the disease to others."},
                new SafetyTip(){Title = "Not Well ?",
                    ImageUrl = "https://images.unsplash.com/photo-1583431444104-d033d7a76404?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=889&q=80",
                    Body = "If you fill off here are some tips to follow to protect yourself and your loved ones",
                
                    SafetySteps = new List<SafetyStep>()
                    {
                        new SafetyStep(){ Title = "Tip 1",Body = "Stay home when you are sick."},
                        new SafetyStep(){Title = "Tip 2", Body = "Avoid touching your eyes, nose or mouth."},
                        new SafetyStep(){Title = "Tip 3", Body = "Stay home when you are sick."},
                        new SafetyStep(){Title ="Tip 4" ,Body = "Cover your nose and mouth with a tissue when coughing or sneezing, and throw the tissue away after use. If a tissue isn’t available, cough or sneeze into your elbow or sleeve, not your hands"},
                        new SafetyStep(){Title = "Tip 5", Body = "Wash your hands often with soap and water for at least 20 seconds, especially after going to the bathroom; before eating; and after blowing your nose, coughing or sneezing. If soap and water are not readily available, use an alcohol-based hand sanitizer with at least 60% alcohol. Always wash hands with soap and water if hands are visibly dirty."},
                        new SafetyStep(){Title = "Tip 6", Body = "Practice other good health habits. Get plenty of sleep, be physically active, manage your stress, drink plenty of fluids and eat nutritious food."},
                        new SafetyStep(){Title ="Tip 7", Body = "Clean and disinfect doorknobs, switches, handles, computers, telephones, bedside tables, bathroom sinks, toilets, counters, toys and other surfaces that are commonly touched around the home or workplace."},
                        new SafetyStep(){Title = "Tip 8", Body = "To the extent possible, avoid touching commonly used surfaces in public places like elevator buttons, door handles and handrails and avoid handshaking with people. Use a tissue or your sleeve to cover your hand or finger if you must touch something."},
                        new SafetyStep(){Title = "Tip 9", Body ="Final and foremost Wear a mask,CDC does not recommend that people who are well wear a facemask to protect themselves from respiratory diseases, including COVID-19.Facemasks should be used by people who show symptoms of COVID-19 to help prevent the spread of the disease to others."}
                    }
                },
                new SafetyTip(){Title = "Be Prepared Always prepared", ImageUrl="https://images.unsplash.com/photo-1580361543250-301150bf6551?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=751&q=80" ,Body = "Stock up Food Supplies" ,
               
                   SafetySteps = new List<SafetyStep>()
                   {
                       new SafetyStep(){ Title ="Step 1 ",Body = "Contact your healthcare provider to ask about obtaining extra necessary medications to have on hand in case there is an outbreak of COVID-19 in your community and you need to stay home for a prolonged period of time."},
                       new SafetyStep(){Title = "Step 2 ",Body = "If you cannot get extra medications, consider using a mail-order option."},
                       new SafetyStep(){Title = "Step 3", Body = "Be sure you have over-the-counter medicines and medical supplies (tissues, etc.) to treat fever and other symptoms. Most people will be able to recover from COVID-19 at home."},
                       new SafetyStep(){Title = "Step 4 ", Body = "Have enough household items and groceries on hand so that you will be prepared to stay at home for a period of time."},
                   }
                },
                new SafetyTip(){Title = "What to Do in emergency Situation",ImageUrl="https://images.unsplash.com/photo-1520531971933-0ad2edaea16e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=750&q=80"  ,Body = "There are things you can do right now to be ready for any emergency, and many of these same tips will help you prepare as the coronavirus situation",
                SafetySteps = new List<SafetyStep>()
                {
                    new SafetyStep(){ Title = "Step 1 ", Body = "Have a supply of food staples and household supplies like laundry detergent and bathroom items, and diapers if you have small children."},
                    new SafetyStep(){ Title = "Step 2", Body = "Check to make sure you have at least a 30-day supply of your prescription medications, and have other health supplies on hand, including pain relievers, stomach remedies, cough and cold medicines, fluids with electrolytes and vitamins."},
                    new SafetyStep(){ Title = "Step 3", Body = "Learn how your children’s school or daycare, and your workplace will handle a possible outbreak. Create a plan in the event of any closings, event cancellations or postponements."},
                    new SafetyStep(){Title = "Step 4", Body = "If you care for older adults or children, plan and prepare for caring for them, should they or you become sick."},
                    new SafetyStep(){ Title = "Step 5", Body = "Help family members and neighbors get prepared and share the safety messaging with those who may not have access to it."},

                }
                }
            };
        }
    }
}
