# MicroServicesDemo_NET8

## Branch Master Protection

## Github settings >> 
-- branch setting >> 
-- addrule or edit rule >> 
-- untick require approval >> 
-- tick Do not allow bypassing the above settings 

## Adding Coupon-service-api

# Sync master

Enables these commonly used commands:
Add-Migration
Bundle-Migration
Drop-Database
Get-DbContext
Get-Migration
Optimize-DbContext
Remove-Migration
Scaffold-DbContext
Script-Migration
Update-Database


<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.3" />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.3">

<PackageReference Include="AutoMapper" Version="13.0.1" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.0" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />


### use post body api swagger with coupon id = 0 when create 
{
  "couponId": 0,
  "couponCode": "40off",
  "discountAmount": 40,
  "minAmount": 40
}


# Authentication Api 
-- ApplicationUser : IdentityUser add migrations 


{
  "email": "Admin@Admin.com",
  "name": "Admin",
  "phoneNumber": "1234567890",
  "password": "Admin@123",
  "role": "Admin"
}

# PRODUCT-API

# Home Page- UI & API

# SHOPPING-API 

shopping cart save 

{
  "cartHeader": {
    "cartHeaderId": 0,
    "userId": "string",
    "couponCode": "string",
    "discount": 0,
    "cartTotal": 0
  },
  "cartDetails": [
    {
      "cartDetailsId": 0,
      "cartHeaderId": 0,      
      "productId": 0,     
      "count": 0
    }
  ]
}
update
 {
  "cartHeader": {
    "cartHeaderId": 1,
    "userId": "1userid",
    "couponCode": "",
    "discount": 0,
    "cartTotal": 1001
  },
  "cartDetails": [
    {
      "cartDetailsId": 0,
      "cartHeaderId": 0,      
      "productId": 3,     
      "count": 3
    }
  ]
}

# Shopping-Cart-UI

# SERVICE-BUS

-- Add Project Refrence in Mango.Service.ShoppingCartAPI (ref - Mango.MessageBus)
-- Login to Azure Portal
-- Create Service Queue
-- Shared Policies //// get copy  of Primary Connection-string
-- Controlller CreateIndex.cshtml aspAction Email Cart , 
-- DI MessageBus in APIConttroller
-- Appsettings.Json TopicAndQueueNames


## EMAIL-API 

## Checkout ORDER-UI & ORDER-API

## STRIPE-CHECKOUT API