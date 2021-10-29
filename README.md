# MG.NovinPayment

This package for BNovinE Payment Gateway | درگاه پرداخت بانک اقتصاد نوین  

## Installation

Use the Nuget package manager  to install MG.NovinPayment.

```bash
Install-Package MG.NovinPayment -Version 1.2.0
```

## Startup - DpenedenciInjection
```csharp
using MG.NovinPayment.DpenedenciInjection;

public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMGNovinPayment();
        }
```

## Controller

```csharp
using MG.NovinPayment.Models.PardakhNovinMethods;

 public class HomeController : Controller
    {
        private readonly IPardakhtNovin _pardakht;

        public HomeController( IPardakhtNovin pardakht)
        {
            
            _pardakht = pardakht;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _pardakht.LoginAsync("UserName", "Password");
            return View();
        }

     }

```


 همه متد های مورد نیاز برای کار کردن با درگاه پرداخت در اینترفیس  که تزیق شده است موجود 

## نکته:
 متد ها به 2 صورت پیاده سازی شده اند .  ادرس درگاه خودتان بهش  پاس میدهید یکی خودش ادرس درگاه را دارد فقط شما کافی هست پارامترهای که از شما خواسته است را پر کنید.


## NuGet URL
[Click Here ](https://www.nuget.org/packages/MG.NovinPayment/)
