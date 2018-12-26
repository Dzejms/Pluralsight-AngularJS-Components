using CourseViewer.Data.Entities;
using CourseViewer.Data.Interfaces;
using CourseViewer.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            // EXEC sp_msforeachtable 'drop table ?'
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1 - Seed CourseViewer database.");
                Console.WriteLine("2 - Test data retrieval.");
                Console.WriteLine("0 - Exit.");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Seed();
                        break;
                    case "2":
                        Test();
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
        }

        static void Seed()
        {
            #region authors

            Console.WriteLine();

            List<Author> authors = new List<Author>();

            authors.Add(new Author()
            {
                FirstName = "Miguel",
                LastName = "Castro",
                Bio = "Whether playing on the local Radio Shack’s TRS-80 or designing systems for clients around the globe, Miguel has been writing software since he was 12 years old. He insists on staying heavily involved and up-to-date on all aspects of software application design & development, and projects that diversity onto the type of training and consulting he provides to his customers and believes that it’s never just about understand the technologies, but how technologies work together. Miguel is a Microsoft MVP since 2005 and when he’s not consulting or training, Miguel speaks at conferences around the world, practices combining on-stage tech and comedy, and never misses a Formula 1 race."
            });
            authors.Add(new Author()
            {
                FirstName = "Brian",
                LastName = "Noyes",
                Bio = "Brian Noyes is CTO and Architect at Solliance (www.solliance.net), an expert technology solutions development company. Brian is a Microsoft Regional Director and MVP, and specializes in rich client technologies including XAML and HTML 5, as well as building the services that back them with WCF and ASP.NET Web API. Brian has authored several books including Developer's Guide to Microsoft Prism 4, Data Binding with Windows Forms 2.0, and Smart Client Deployment with ClickOnce. He publishes articles frequently in a variety of publications and speaks at conferences worldwide including Microsoft TechEd, DevConnections, DevIntersection, VSLive!, DevTeach and others. Brian got started programming as a hobby while flying F-14 Tomcats in the U.S. Navy, later turning his passion for software into his current career."
            });
            authors.Add(new Author()
            {
                FirstName = "Scott",
                LastName = "Allen",
                Bio = "Scott has worked on everything from 8-bit embedded devices to large scale web sites during his 15+ years in commercial software development. Since 2001, Scott has focused on server-side and web technologies, like ASP.NET, ASP.NET AJAX, Windows Workflow, Silverlight, and LINQ. Scott is also a speaker at national conferences like VSLive!, as well as code camps and user groups near his hometown of Hagerstown, MD. Scott has been recognized as a Microsoft MVP since 2005, and has written or co - authored several books on Microsoft technologies.Scott founded the site OdeToCode.com in 2004, and joined Pluralsight in 2007."
            });
            authors.Add(new Author()
            {
                FirstName = "Chris",
                LastName = "Klug",
                Bio = "Chris Klug is a software developer and architect from Sweden who has spent the better part of his life solving problems by writing software. He loves the creative side of coding as well as the challenges offered by building complex UIs. He also spends a significant amount of his time presenting at developer conferences around the world--something that has apparently caught Microsoft's attention as they have awarded him Microsoft MVP for five years running. It's an award he is very proud of, and he hopes to keep being awarded if possible. But when asked, he has no problem admitting that he would rather be kite-boarding on a nice beach or having one of his tattoos extended than playing with his computer."
            });
            authors.Add(new Author()
            {
                FirstName = "Adam",
                LastName = "Tuliper",
                Bio = "Adam Tuliper is a software architect with Cegedim and has been developing software for over 16 years. He's a Certified Scrum Master and MCPD Enterprise Applications Developer. Adam started his work in security and reverse engineering (x86 based - pre .NET) with the direction of going into the software protection and anti-piracy field. He has been deeply involved in .NET internals since early .NET beta and currently works extensively with WCF, ASP.NET, SQL Server, MVC, C#, jQuery, and Silverlight. Adam is a top rated INETA Community Speaker, MSDN Magazine Author, national conference speaker, and regularly speaks at .NET User Groups and code camps. Besides development, he has performed security audits and penetration testing for large and small companies alike and really likes security."
            });
            authors.Add(new Author()
            {
                FirstName = "Brian",
                LastName = "Lagunas",
                Bio = "Brian Lagunas is a Microsoft MVP, a Microsoft Patterns & Practices Champion, Director of Technology for INETA, co-leader of the Boise .Net Developers User Group (NETDUG), board member of Boise Code Camp, speaker, trainer, author, and original creator of the Extended WPF Toolkit. He is a multi-recipient of the Microsoft Community Contributor Award and can be found speaking at a variety of user groups and code camps around the world. His talks always involve some form of XAML, such as WPF, Silverlight, and Windows 8, as well as how to build modular applications with Prism. Brian currently works at Infragistics as a Product Manager for Infragistics’ award winning WPF and Silverlight, and Windows UI components.This is where he helps build tools that empower developers to quickly and easily build and style dynamic applications with immersive UX and vibrant data visualization in line of business applications, across all XAML platforms.Prior to working at Infragistics he worked in the construction and engineering industry as a senior software engineer and software solution architect where he specialized in enterprise application development.Before geeking out, Brian served his country in the United States Army as an infantryman and later served his local community as a deputy sheriff. In his spare time he authors courses for Pluralsight, blogs about XAML technologies.The easiest way to find Brian is on twitter at @BrianLagunas."
            });
            authors.Add(new Author()
            {
                FirstName = "John",
                LastName = "Sonmez",
                Bio = "John Sonmez is the founder of Simple Programmer, where he tirelessly pursues his vision of transforming complex issues into simple solutions. John has published over 50 courses on topics such as iOS, Android, .NET, Java, and game development for the online developer training resource, Pluralsight. He also hosts the GetUp and CODE podcast, where he talks about fitness for programmers. John is a life coach for software developers, and helps software engineers, programmers and other technical professionals boost their careers and live a more fulfilled life. He empowers them to accomplish their goals by making the complex simple."
            });

            IAuthorRepository authorRepository = new AuthorRepository();

            for (int i = 0; i < authors.Count; i++)
            {
                authors[i] = authorRepository.Add(authors[i]);
                Console.WriteLine("Added author '{0} {1}'", authors[i].FirstName, authors[i].LastName);
            }

            #endregion

            #region courses

            Console.WriteLine();

            List<Course> courses = new List<Course>();

            courses.Add(new Course() // 1
            {
                CourseName = "Building End-to-End Multi-Client Service Oriented Applications - Angular Edition",
                Summary = "This course will take you through the development of a service oriented application from beginning to end and will include multiple types of clients.",
                Description = "It seems to me that the longer I stay in this business, the shorter the time between new technology releases. There's enough stuff out there in the development world to keep us both excited and overwhelmed. Learning new tech has become easier with the all the information available to us, especially in the way of these Pluralsight courses. But learning how to use a technology and learning how to properly implement it or integrate it with other technologies can be a whole different ballgame. Service-Oriented systems have become mainstream, but designing applications in a service-oriented fashion require a different look on the components that make it up as well as technologies to support the architecture. This course will bring it all together for you by building on knowledge you have on technologies like WCF, Web API, ASP.NET MVC, WPF, and AngularJS and going from A to Z on the architecture, design, development, and testing of a complete system. And this system will not only use a multitude of technologies in the middle-tier, but will also be consumed by different UI clients on the web and the desktop. Know how to write services in WCF and Web API, but want to see some real-world implementation from both MVC and WPF clients, then this course is for you. Want to know how to implement dependency injection from the middle tier to the various UIs, then this course is for you. Want to write decoupled, testable software, then this course is for you. The final set of applications can be used as a skeleton and framework for any SOA-based system you write going forward, and the techniques used in its development will become part of your development arsenal forever.",
                Released = Convert.ToDateTime("9/18/2014"),
                AuthorId = authors[0].AuthorId
            });

            courses.Add(new Course() // 2
            {
                CourseName = "Developing Extensible Software",
                Summary = "This course will teach you patterns that allow you to build your software out of swappable building blocks, as well as allow future developers to extend it easily.",
                Description = "In today's competitive world of software development, using methodologies such as Agile lets us get products to market quicker and in a controlled fashion, but that's not enough. Applications need to be able to grow without being totally rewritten. Sure, there eventually comes a time when every app needs a major overhaul, but if applications are written to be extensible in the first place, the overhaul can be performed in pieces; and in the meantime, new features can be added or existing features changed without bringing the app down. This \"extensibility\"  in our design is becoming more and more important every day as software shops compete with each other for work and even with other countries. There have been many articles and design documents written on things like inversion of control in the UI tiers. Many books have dedicated chapters to injecting objects into MVC controllers or WPF ViewModels, but not many have focused on the meat of a system, the business tiers. These are the tiers that are accessible to the UI of a system, more than one in many cases. And these are the tiers that can be most volatile and subject to change and enhancement. In this course, I'll show you some of my favorite extensibility designs and techniques which will let you write software in building blocks that can be connected and interconnected in different ways. I'll keep most of my focus on the business tiers, which despite the lack of user-centric visual glamour, is where you get to exercise the most creativity. You'll be able to roll out applications and continuously add or change things without affecting the core infrastructure in place. To me, this not only makes the software better, but more fun to write!",
                Released = Convert.ToDateTime("2/4/2014"),
                AuthorId = authors[0].AuthorId
            });

            courses.Add(new Course() // 3
            {
                CourseName = "WCF End-to-End",
                Summary = "WCF End-to-End will take you from zero to hero on Microsoft's richest service-oriented technology. You'll learn how to write services that have very rich characteristics including state, transactions, fault-handling, callbacks, and even security.",
                Description = "WCF is NOT dead! Got your attention? It's important to get that out of the way because in today's world, the lack of discussion of a technology is often misinterpreted as the death of a technology. The artist formerly known as Indigo (WCF) has been generally available since Visual Studio 2005 and is still the best platform for writing service or messaging-based systems on the Microsoft platform. What about Web API, you ask? WCF and Web API are drastically different platforms with different goals and purposes. WCF offers the richest and most robust programming model for exposing services with characteristics and capabilities not available in any other messaging technology. Capabilities like state-management, callback eventing, and transaction handling. In this course, I'll teach you WCF from beginning to end. You're getting absolutely everything you will need to get the job done in a service oriented environment and to take advantage of all the richness the WCF platform has to offer. Nothing will be left to chance here so come to learn to do it right, and see how easy it can truly be.",
                Released = Convert.ToDateTime("3/8/2015"),
                AuthorId = authors[0].AuthorId
            });

            courses.Add(new Course() // 4
            {
                CourseName = "WCF Power Topics",
                Summary = "WCF goes way beyond just exposing data and behavior through services. It is truly different from Web API and every other service technology out there. These topics show you why.",
                Description = "OK so you watched WCF End-to-End, wait, you didn't? OK stop and go watch it now… you're back and watched it, great. Now you're ready for some more advanced stuff. This is where WCF super-shines because it's capable of stuff that's just not doable with other technologies. You can add capabilities to your applications or system of applications that will take them to the edge of functionality and coolness. I'll teach you how to leverage WCF's extensibility by customizing parts of it to meet your needs. You can enjoy this course in its entirety or just target the modules that you feel will help you in your particular situation. Let's continue this journey, on what is still today, the richest service technology in the Microsoft stack.",
                Released = Convert.ToDateTime("2/29/2016"),
                AuthorId = authors[0].AuthorId
            });

            courses.Add(new Course() // 5
            {
                CourseName = "Designing & Building Component-Based AngularJS Applications",
                Summary = "This course will bridge the gap between AngularJS and Angular by teaching you how to design and build applications in AngularJS using the component-based paradign that Angular forces you to use.",
                Description = "Angular 2, or whatever they're calling it now, is forcing us to learn new syntax, new installation procedures, and of course wants us to use TypeScript. But the single most significant change is that it forces us down the path of component-based design. In fact, it does not give us a choice. This is not a bad thing; in fact it's a absolutely awesome way to design and write web applications. But what if you are not ready to make the leap to the next version of Angular, whether for personal reasons or those of your place of employment? Well, Angular 1.5 (now 1.6) backported the idea of components directly from Angular 2's design. Now you can design and develop your web applications using this great modular and encapsulated paradigm. And you can do it using the familiar Angular 1 environment that in all honesty, is not going anywhere any time soon. In this course, I'll teach you how to do design and develop these kind of applications. You'll be leveraging all of your existing Angular knowledge but learning an awesome hierarchical way of designing, making your web site a tree of components. I'll also teach you how to use the Angular UI Router which replaces the now deprecated Component Router, but offers you the same nested routing capability that you'll find in the new Angular 2 router. This component-based way of writing web applications will train your brain to the way Angular 2 will force you to do things so you'll be able to jump into it when you're ready, and you'll be one step ahead of the game already.",
                Released = Convert.ToDateTime("4/30/2017"),
                AuthorId = authors[0].AuthorId
            });

            courses.Add(new Course() // 6
            {
                CourseName = "WPF MVVM In Depth",
                Summary = "This course provides end-to-end coverage of what you need to know to effectively apply the MVVM pattern to WPF applications.",
                Description = "This course introduces WPF developers to the MVVM design pattern and teaches them how to apply it to a wide range of compositional scenarios for building out WPF client applications. The course covers the motivations for using the pattern, the fundamental concepts of the pattern, and then demonstrates how to apply it for a number of common scenarios. It covers various different ways of defining Views, ViewModels, and attaching to one another. It shows how to use common data bound controls in the context of MVVM and how to hook them to ViewModels and Models, both statically and dynamically. It shows how to communicate between View and ViewModel with data binding, commands, and behaviors. Finally, it shows how to use View and ViewModel hierarchies and set up navigation between Views within a container.",
                Released = Convert.ToDateTime("6/12/2015"),
                AuthorId = authors[1].AuthorId
            });

            courses.Add(new Course() // 7
            {
                CourseName = "WPF Productivity Playbook",
                Summary = "This course contains a collection of tips, tricks, and techniques that will help you become a more productive and confident WPF developer, able to leverage the full power of the platform.",
                Description = "This course, WPF Productivity Playbook, walks you through a couple dozen capabilities and techniques with WPF that will help you fully harness the WPF platform to build user interfaces that delight your users while letting you be as productive as possible writing clean, maintainable code. First, you'll to see some the best ways to be productive using the Visual Studio XAML designer to layout controls, as well as how to use drag and drop data binding features in the designer. Next, you'll use the template editing modes of Blend and Visual Studio to have a visual editing experience when working with custom controls, ControlTemplates, and DataTemplates. You'll also get some XAML coding guidelines that you can use when writing XAML by hand to make sure that code is easy to read and more maintainable. After completing this course, you'll be ready to unlock the full potential of Visual Studio and Blend tooling.",
                Released = Convert.ToDateTime("8/22/2016"),
                AuthorId = authors[1].AuthorId
            });

            courses.Add(new Course() // 8
            {
                CourseName = "WCF Jumpstart",
                Summary = "This course is designed to get you from no knowledge of Windows Communication Foundation (WCF), to up and running with the basics of WCF in a very short time.",
                Description = "In this course, you will get up and running quickly with Windows Communication Foundation (WCF) in a couple of hours. You'll learn the fundamental concepts behind WCF, including what it's for, and what the building blocks are that you will use in implementing services and clients. You'll see how to define service contracts, data contracts, and services. Then you will see how to get the service hosted and configure its endpoints, behaviors, and bindings. Next, you'll see how to quickly implement clients and code to generate the proxy needed to connect to the service. Finally, you will get a quick introduction to security so that you can deploy your services with security protecting them.",
                Released = Convert.ToDateTime("7/16/2014"),
                AuthorId = authors[1].AuthorId
            });

            courses.Add(new Course() // 9
            {
                CourseName = "Aurelia Fundamentals",
                Summary = "This course gives you an end to end coverage of the features of Aurelia, including the MVVM pattern, data binding, routing, dependency injection, and extensibility.",
                Description = "Modern web client applications present new challenges for web developers to deliver rich, maintainable, and interactive web applications written with HTML, CSS, and JavaScript. In Aurelia Fundamentals, you will learn the skills you need to write maintainable, testable, and extensible client applications that are engaging, interactive, and responsive for your users. You will learn how to leverage all of the key features of Aurelia, including UI composition with the Model-View-ViewModel (MVVM) pattern; leveraging rich two-way data binding to decouple your views and UI logic and present rich data and content to your users; and client side routing and navigation that brings together the loosely coupled views into a cohesive whole for the end user. When you are finished with this course, you will have a solid, foundational understanding of all of the capabilities of the Aurelia framework and will be ready to start building amazing Aurelia web client applications that will delight your users.",
                Released = Convert.ToDateTime("5/4/2016"),
                AuthorId = authors[1].AuthorId
            });

            courses.Add(new Course() // 10
            {
                CourseName = "C# Fundamentals with Visual Studio 2015",
                Summary = "C# Fundamentals covers all the essential topics you need for developing with the C# programming language.",
                Description = "In this course, we'll see how to build classes, program with objects, and work with interfaces using the C# language.",
                Released = Convert.ToDateTime("9/25/2015"),
                AuthorId = authors[2].AuthorId
            });

            courses.Add(new Course() // 11
            {
                CourseName = "ASP.NET MVC 5 Fundamentals",
                Summary = "ASP.NET MVC 5 Fundamentals covers all the new features of ASP.NET MVC 5, as well as the new features for web developers in Visual Studio 2013, including WebApi 2, OWIN, Katana, SignalR, and the Entity Framework version 6.",
                Description = "ASP.NET MVC 5 Fundamentals covers all the new features of ASP.NET MVC 5, as well as the new features for web developers in Visual Studio 2013. The course looks at the Katana and OWIN middleware components to see how the components work at a low level and how they fit into ASP.NET pipeline. The new identity and membership components are covered, and a demonstration is included to customize and seed the membership database. We look at Bootstrap 3's grid and responsive design system, as well as the Web API 2, including a demo of making authenticated calls against a Web API from JavaScript. The Entity Framework version 6 is covered including the new async API in EF6, and we'll build an application to stream performance counter data using SignalR and Knockout. Finally, there are tips and tricks for editing HTML, JavaScript, CSS and LESS with Visual Studio 2013 and extensions like Web Essentials, which brings the Zen Coding plugin to the Visual Studio.",
                Released = Convert.ToDateTime("11/4/2013"),
                AuthorId = authors[2].AuthorId
            });

            courses.Add(new Course() // 12
            {
                CourseName = "ASP.NET Core Fundamentals",
                Summary = "This course will cover the fundamentals of what you need to know to start building your first ASP.NET Core application with the MVC framework.",
                Description = "ASP.NET core is the new web framework from Microsoft, redesigned from the ground up to be fast, flexible, modern, and work across different platforms. In this course, ASP.NET Core Fundamentals, you will build an ASP.NET Core application from scratch. Along the way, you will learn about middleware, controllers, views, and models. Next, you'll learn about supporting SQL Server using the Entity Framework and user registration with the Identity Framework. Finally you'll also see novel techniques for working with front end frameworks like Bootstrap and JavaScript libraries like jQuery. By the end of the course, you'll have everything you need to start building applications with the ASP.NET Core framework.",
                Released = Convert.ToDateTime("9/30/2016"),
                AuthorId = authors[2].AuthorId
            });

            courses.Add(new Course() // 13
            {
                CourseName = "Play by Play: C# Q&A with Scott Allen and Jon Skeet",
                Summary = "In this Play by Play course, Jon Skeet and Scott Allen answer real-world C# questions from Stack Overflow. Learn how the experts solve problems, and practical skills that can improve your own work in C#.",
                Description = "Play by Play is a series of courses that allows you to see top developers and designers in real-time, real-world problem-solving sessions. In this particular C# course, Jon Skeet of Stack Overflow fame matches up with Pluralsight's Scott Allen to answer carefully-selected questions from Stack Overflow. You'll get to see how these experts think through and solve complicated problems in C#, ranging from simple LINQ queries to more difficult threading issues, and you'll also learn a few practical tips and tricks as you go. By the end of this course, you'll have the critical thinking skills needed to approach problems in C# like the experts do, and you'll be able to apply the tips and tricks you learn from them to your own work in C#.",
                Released = Convert.ToDateTime("3/16/2016"),
                AuthorId = authors[2].AuthorId
            });

            courses.Add(new Course() // 14
            {
                CourseName = "Angular JS: Get Started",
                Summary = "This course demonstrates how to use the essential abstractions of AngularJS, including modules, controllers, directives, and services.",
                Description = "AngularJS is a complete JavaScript framework for creating dynamic and interactive applications in HTML. This course is designed to cover the core features of the framework using practical, easy to follow examples. We will see how two-way data binding makes it easy to build pages and forms while maintaining simplicity in the JavaScript code, and come to understand the essential abstractions of AngularJS, including modules, controllers, directives, and services. By the end of the course, you'll be able to start building your own single page application using AngularJS.",
                Released = Convert.ToDateTime("7/5/2014"),
                AuthorId = authors[2].AuthorId
            });

            courses.Add(new Course() // 15
            {
                CourseName = "Understanding OWIN and Katana",
                Summary = "This course gives you an introduction to OWIN and Project Katana, and shows how you can use it while building your web applications.",
                Description = "Have you ever wished you could have a low hassle, easy to use, configurable way of building web applications in .NET? Maybe the ability to write a web application in just a few lines, as you can in Node.js? Well, OWIN gives you this, and then some. In this course, you will gain an understanding of how OWIN works and how it can do wonders for your .NET based web application development.",
                Released = Convert.ToDateTime("10/27/2015"),
                AuthorId = authors[3].AuthorId
            });

            courses.Add(new Course() // 16
            {
                CourseName = "Hack-proofing Your ASP.NET Web Applications",
                Summary = "This course provides the developer with techniques for hack-proofing their applications by understanding the attacks that are used, and how to defend against them.",
                Description = "Developers are notoriously lax in security. Part of the problem is not understanding how our applications are attacked. To protect your applications you need to BE a hacker. You need to understand how your applications are hacked, and therefore, how to protect them. This course goes over the most common hacking techniques using an array of current attacks to show how a web application is exploited. This course covers exploits and protections for both Web Forms and MVC. Covered are such topics as sql injection, parameter tampering, information leakage, cross-site scripting (xss), cross-site request forgery, encryption, hashing, and denial of service all with applicable demos.",
                Released = Convert.ToDateTime("2/2/2012"),
                AuthorId = authors[4].AuthorId
            });

            courses.Add(new Course() // 17
            {
                CourseName = "Introduction to WPF Custom Controls",
                Summary = "Introduction to WPF Custom Controls is an introductory course designed to teach the basic concepts required to get started writing custom WPF controls.",
                Description = "Introduction to WPF Custom Controls is an introductory course designed to teach the basic concepts required to get started writing custom WPF controls. Learn how to choose a base class to start your custom control. Enable data binding support by adding your own custom properties. Learn how to add custom events and create custom commands. Add visual behavior to your custom control with the use of triggers and the visual state manager. You'll also learn how to add theming support to your custom control.",
                Released = Convert.ToDateTime("7/31/2013"),
                AuthorId = authors[5].AuthorId
            });

            courses.Add(new Course() // 18
            {
                CourseName = "What's New in Prism 5.0",
                Summary = "What's New in Prism 5.0 covers all the breaking changes, new features, and new assemblies in the newest release of Microsoft Patterns and Practices Prism 5.0 library.",
                Description = "What's New in Prism 5.0 covers all the breaking changes, new features, and new assemblies in the newest release of Microsoft Patterns and Practices Prism 5.0 library. This course will tell you the new dependencies your applications will require. We will also discuss the breaking changes, deprecated objects, and new objects you should use, how to upgrade your existing applications, and all the new features and functionality that has been added to Prism 5.0.",
                Released = Convert.ToDateTime("7/13/2014"),
                AuthorId = authors[5].AuthorId
            });

            courses.Add(new Course() // 19
            {
                CourseName = "The Go Programming Language",
                Summary = "In this course we will learn about the Go programming language from Google. We'll cover most of the language and look at interesting topics like concurrency.",
                Description = "Go is awesome! It looks like C, but don't be deceived - it is completely different! The Go Programming Language is a new programming language from Google. It is very different than many other modern programming languages, and is a great substitute for C or C++. In this course we will cover most of the Go programming language and look at some of the neat things we can do with Go. We'll progressively cover each important concept in the language and finally end by looking at concurrency (which is built into the language.) If you are looking for an extremely fast an efficient language that is an elegant replacement for traditional systems programming languages like C or C++, Go might be just what you are looking for. Go allows you many of the benefits of powerful low level languages, but is very easy to use and designed with today's programming environment in mind. By the end of this course you should be ready to start programming in Go!",
                Released = Convert.ToDateTime("2/14/2013"),
                AuthorId = authors[6].AuthorId
            });

            courses.Add(new Course() // 20
            {
                CourseName = "Preparing For a Job Interview",
                Summary = "This course covers some of the most important things you need to know to help you succeed in a developer job interview.",
                Description = "Job interviews can be very difficult and intimidating. When you need a job, it is important to have good job interviewing skills and know what to expect. The only problem is, it is very difficult to get experience with job interviews, because we don't do them that often. This course is designed to make you feel much more prepared for a developer job interview by going over the process and talking about many of the types of questions you are likely to encounter. In this course we'll go over the basics of a job interview and talk about specifically what employers are looking for and how you can improve your resume. I'll teach you some tricks that increase the chances of you getting an interview greatly. We'll also go over one of the most difficult and scary parts of a developer job interview, solving a coding question on the spot. I'll walk you through my own personal technique for solving these types of problem and take you step by step through an example, so that you can gain the skills and experience that will help you feel comfortable to tackle these kinds of problems on your own. Our journey will then takes us through some typical interview questions to help you understand what types of thing you should know and prepare for and the best way to answer these types of questions. Then we'll go through a blazing fast boot camp for computer science questions about data structures, algorithms, bit manipulation, and concurrency... All the fun stuff you forgot about from college. And finally we'll wrap up by talking about how you can get experience if you don't have any, and what kind of experience is valuable. If you are looking for a job currently or just want to brush up on your skills to be prepared, this course might be just for you.",
                Released = Convert.ToDateTime("3/10/2013"),
                AuthorId = authors[6].AuthorId
            });

            courses.Add(new Course() // 21
            {
                CourseName = "Using The Chrome Developer Tools",
                Summary = "An exploration of every one of the 8 panels that exist in the Chrome Developer Tools toolbar.",
                Description = "Did you know that you can modify just about any part of a web page live in your browser? What about setting breakpoints that automatically trigger whenever an AJAX call is made, or whenever a specific element on a page is modified? You can do all this and more with the Chrome Developer Tools, and in this course I'll show you how. If you've seen the Chrome Developer Tools, but just not had the time to really dig into them, or you get the feeling that you are only scratching the surface of what the Chrome Developer Tools can do, this course might be exactly what you need to take your web development abilities to the next level. I've found that many web developers are only aware of the basic features of the Chrome Developer Tools, so I've structured this course to go over just about every inch of the tools and explain clearly what they do and how you can use them. In this course we'll cover every one of the 8 panels that exist in the Chrome Developer Tools toolbar. We'll start off by going over the function of the console, giving you the ability to modify JavaScript objects interactively on the page, debug issues and add helpful log messages with ease. Then, we'll take a trip to the elements panel where we'll be seeing how to modify HTML and CSS styles and see the effects immediately displayed on the page. After that, we'll check out the network panel and how to find out exactly what resources our pages are getting from the network, how long it is taking to get them, and what order all of this is happening in. Then, we'll head over to the sources panel and unveil the powerful built-in JavaScript debugging capabilities that Chrome has out of the box. (You won't want to miss this part.) We'll follow up with a quick review of the audits panel to see how it can give us some handy optimization tips for our pages. Then we'll dig into the timeline panel where we'll learn how to figure out exactly what is happening when a page is being displayed and how to optimize our pages to ensure the animation is never choppy. Finally, we'll wrap things up by seeing how the profiles panel can help us quickly identify performance problems with JavaScript or CSS selectors and also let us see into the scary realm of JavaScript memory management. If you’ve been waiting for the right time to really dig into the Chrome Developer Tools and see what all they can do, that time has come!",
                Released = Convert.ToDateTime("4/24/2013"),
                AuthorId = authors[6].AuthorId
            });

            courses.Add(new Course() // 22
            {
                CourseName = "Introduction to Objective-C",
                Summary = "A basic introduction to the Objective-C programming language and XCode IDE.",
                Description = "Learning Objective-C can be intimidating for developers looking to learn some Mac OS X or iOS development skills. This course is designed to make that process easy and as painless as possible. We will start at the very basics of the Objective-C programming language and focus on getting a good practical understanding of the language. This course is designed to cover basic topics that can help you to be introduced to the language without being overwhelmed. By then end of this course, you should have the skills you need to understand and write basic Objective-C programs.",
                Released = Convert.ToDateTime("1/3/2012"),
                AuthorId = authors[6].AuthorId
            });

            ICourseRepository courseRepository = new CourseRepository();

            for (int i = 0; i < courses.Count; i++)
            {
                courses[i] = courseRepository.Add(courses[i]);
                Console.WriteLine("Added course '{0}'", courses[i].CourseName);
            }

            #endregion

            #region course modules

            Console.WriteLine();

            List<CourseModule> courseModules = new List<CourseModule>();

            courseModules.Add(new CourseModule()
            {
                Title = "Welcome and Course Description",
                Minutes = 9,
                Seconds = 17,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Demo of a Service Oriented Application",
                Minutes = 10,
                Seconds = 45,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "SOA and Technology",
                Minutes = 16,
                Seconds = 36,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Architecture and Database",
                Minutes = 21,
                Seconds = 10,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Entities and Core",
                Minutes = 66,
                Seconds = 36,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Data Access (starting the business tier)",
                Minutes = 74,
                Seconds = 34,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Services and Business Engines - Part 1",
                Minutes = 62,
                Seconds = 33,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Services and Business Engines - Part 2",
                Minutes = 60,
                Seconds = 34,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Service Hosting",
                Minutes = 45,
                Seconds = 59,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Client Access",
                Minutes = 40,
                Seconds = 45,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Car Rental Website - Part 1",
                Minutes = 69,
                Seconds = 34,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Car Rental Website - Part 2",
                Minutes = 93,
                Seconds = 45,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Car Rental Website - Part 3",
                Minutes = 76,
                Seconds = 15,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Car Rental Desktop - Part 1",
                Minutes = 35,
                Seconds = 53,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Can Rental Destop - Part 2",
                Minutes = 65,
                Seconds = 34,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Conclusion and vNext",
                Minutes = 2,
                Seconds = 43,
                CourseId = courses[0].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Welcome and Course Description",
                Minutes = 3,
                Seconds = 52,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Importance of Extensibility",
                Minutes = 9,
                Seconds = 48,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Abstraction and Dependency Injection",
                Minutes = 18,
                Seconds = 15,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Implementing Providers",
                Minutes = 33,
                Seconds = 58,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Implementing Modules",
                Minutes = 53,
                Seconds = 0,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Advanved Module Usage",
                Minutes = 23,
                Seconds = 26,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Pipelines",
                Minutes = 43,
                Seconds = 0,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Procedural Overriding",
                Minutes = 18,
                Seconds = 33,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Using MEF",
                Minutes = 20,
                Seconds = 56,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Conclusion",
                Minutes = 1,
                Seconds = 34,
                CourseId = courses[1].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Welcome and Course Description",
                Minutes = 15,
                Seconds = 10,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Service Orientation and WCF",
                Minutes = 29,
                Seconds = 18,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Contracts and Services",
                Minutes = 43,
                Seconds = 41,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Hosting and Service Configuration",
                Minutes = 44,
                Seconds = 5,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Proxies and Client Configuration",
                Minutes = 58,
                Seconds = 3,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "In-Process and Threading",
                Minutes = 24,
                Seconds = 18,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Bindings and Behaviors",
                Minutes = 60,
                Seconds = 26,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Metadata Exchange",
                Minutes = 23,
                Seconds = 29,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Instancing and Concurrency",
                Minutes = 63,
                Seconds = 21,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Faults and Exceptions",
                Minutes = 23,
                Seconds = 57,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Transaction Handling",
                Minutes = 39,
                Seconds = 5,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Operations",
                Minutes = 65,
                Seconds = 21,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Securing Services",
                Minutes = 96,
                Seconds = 37,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Patterns of Implementation",
                Minutes = 37,
                Seconds = 18,
                CourseId = courses[2].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 23,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Introduction",
                Minutes = 13,
                Seconds = 13,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Extending WCF with Custom Behaviors",
                Minutes = 46,
                Seconds = 29,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Making Your Services Discoverable",
                Minutes = 59,
                Seconds = 32,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Centralizing and Reusing Fault Handling",
                Minutes = 35,
                Seconds = 53,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Working with the Azure Service Bus",
                Minutes = 43,
                Seconds = 16,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "WCF Routing Services",
                Minutes = 54,
                Seconds = 53,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Leveraging HTTPS For WCF Using SSL",
                Minutes = 26,
                Seconds = 52,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Solving Common Problems: Long Running Processes",
                Minutes = 46,
                Seconds = 24,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Solving Common Problems: Versioning Your Services",
                Minutes = 34,
                Seconds = 53,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Solving Common Problems: Fault Reporting for One-way Services",
                Minutes = 15,
                Seconds = 32,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Solving Common Problems: Eventing and Pub/Sub with WCF",
                Minutes = 52,
                Seconds = 22,
                CourseId = courses[3].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 5,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Shifting to a Component-Based Design - Angular Thinking",
                Minutes = 30,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "The Development Environment",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Writing a Component",
                Minutes = 30,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Laying Out Our Component-Based Application",
                Minutes = 30,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Introducing Routing",
                Minutes = 30,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Building Out the Rest of the App Structure",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "The Author List and Course List Components",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Adding Services",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Securing the Application",
                Minutes = 30,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "The Course Component and Its Internal Structure",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "The Author and Author Sidebar Component",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "What About ASP.NET?",
                Minutes = 40,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Integrating ASP.NET Routing",
                Minutes = 20,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Wrap-Up",
                Minutes = 10,
                Seconds = 0,
                CourseId = courses[4].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "MVVM Pattern Fundamentals",
                Minutes = 20,
                Seconds = 47,
                CourseId = courses[5].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "First Taste of MVVM",
                Minutes = 14,
                Seconds = 56,
                CourseId = courses[5].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Hooking up Views and ViewModels in MVVM",
                Minutes = 31,
                Seconds = 9,
                CourseId = courses[5].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "View/ViewModel Communication in WPF",
                Minutes = 30,
                Seconds = 23,
                CourseId = courses[5].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Applied MVVM Part 1 - Hierarchies and Navigation",
                Minutes = 37,
                Seconds = 51,
                CourseId = courses[5].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Applied MVVM Part 2 - Validation and Dependency Injection",
                Minutes = 39,
                Seconds = 48,
                CourseId = courses[5].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 30,
                CourseId = courses[6].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Getting Productive with XAML Layout and Data Binding",
                Minutes = 31,
                Seconds = 56,
                CourseId = courses[6].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Visually Editing Templates & Debugging Your UI",
                Minutes = 34,
                Seconds = 2,
                CourseId = courses[6].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Writing Maintainable XAML Code",
                Minutes = 20,
                Seconds = 14,
                CourseId = courses[6].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Using Blend for Behaviors, Animations, and Visual States",
                Minutes = 41,
                Seconds = 15,
                CourseId = courses[6].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Leveraging WPF Framework Power Features",
                Minutes = 48,
                Seconds = 11,
                CourseId = courses[6].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Hello WCF!",
                Minutes = 21,
                Seconds = 22,
                CourseId = courses[7].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Implementing Services",
                Minutes = 19,
                Seconds = 49,
                CourseId = courses[7].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Hosting Services",
                Minutes = 24,
                Seconds = 57,
                CourseId = courses[7].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Implementing Clients",
                Minutes = 25,
                Seconds = 13,
                CourseId = courses[7].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Quick Intro to WCF Security",
                Minutes = 17,
                Seconds = 58,
                CourseId = courses[7].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 23,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Aurelia Prerequisites",
                Minutes = 53,
                Seconds = 11,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Getting Started with Aurelia",
                Minutes = 45,
                Seconds = 0,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Implementing MVVM with Aurelia",
                Minutes = 30,
                Seconds = 49,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Using Dependency Injection In Aurelia",
                Minutes = 28,
                Seconds = 7,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Aurelia Routing Fundamentals",
                Minutes = 50,
                Seconds = 8,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Aurelia Routing Beyond the Basics",
                Minutes = 53,
                Seconds = 55,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Aurelia Data Binding Fundamentals",
                Minutes = 39,
                Seconds = 11,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Data Binding Beyond the Basics",
                Minutes = 88,
                Seconds = 11,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Working with Services, Plugins, and Pub/Sub Events",
                Minutes = 47,
                Seconds = 12,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Extending Aurelia with Custom Elements and Attributes",
                Minutes = 40,
                Seconds = 45,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Preparing Your Aurelia Application for Production",
                Minutes = 40,
                Seconds = 42,
                CourseId = courses[8].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 19,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "An Introduction to C# and .NET",
                Minutes = 42,
                Seconds = 37,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Classes and Objects",
                Minutes = 48,
                Seconds = 3,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Assemblies",
                Minutes = 36,
                Seconds = 2,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Types",
                Minutes = 49,
                Seconds = 40,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Methods, Field, Events, and Properties",
                Minutes = 46,
                Seconds = 26,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Control Flow",
                Minutes = 53,
                Seconds = 1,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Object Oriented Programming",
                Minutes = 44,
                Seconds = 37,
                CourseId = courses[9].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Introduction and Prerequisites",
                Minutes = 15,
                Seconds = 47,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "OWIN and Katana",
                Minutes = 51,
                Seconds = 13,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Identity and Security",
                Minutes = 54,
                Seconds = 7,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Bootstrap",
                Minutes = 47,
                Seconds = 27,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Web API 2",
                Minutes = 50,
                Seconds = 1,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Entity Framework 6",
                Minutes = 61,
                Seconds = 10,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "SignalR",
                Minutes = 49,
                Seconds = 47,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Web Developer Tools and Visual Studio 2015",
                Minutes = 44,
                Seconds = 45,
                CourseId = courses[10].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 35,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Building Your First ASP.NE Core Application",
                Minutes = 37,
                Seconds = 44,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Startup and Middleware",
                Minutes = 36,
                Seconds = 55,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Controllers in the MVC Framework",
                Minutes = 47,
                Seconds = 41,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Models in the MVC Framework",
                Minutes = 64,
                Seconds = 59,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Using the Entity Framework",
                Minutes = 32,
                Seconds = 20,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Razor Views",
                Minutes = 56,
                Seconds = 13,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "ASP.NET Identity",
                Minutes = 50,
                Seconds = 5,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Front End Framework and Tools",
                Minutes = 29,
                Seconds = 58,
                CourseId = courses[11].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 47,
                CourseId = courses[12].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Dynamic LINQ - Ordering Results",
                Minutes = 13,
                Seconds = 42,
                CourseId = courses[12].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "String Formats with Integer Variables",
                Minutes = 17,
                Seconds = 10,
                CourseId = courses[12].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Automated Properties",
                Minutes = 13,
                Seconds = 14,
                CourseId = courses[12].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Lambda Expression Property Names",
                Minutes = 14,
                Seconds = 5,
                CourseId = courses[12].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Binary Compatibility",
                Minutes = 15,
                Seconds = 26,
                CourseId = courses[12].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Course Overview",
                Minutes = 1,
                Seconds = 18,
                CourseId = courses[13].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "An Introduction",
                Minutes = 34,
                Seconds = 43,
                CourseId = courses[13].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Controllers",
                Minutes = 35,
                Seconds = 43,
                CourseId = courses[13].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Directives and Views",
                Minutes = 33,
                Seconds = 44,
                CourseId = courses[13].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Services",
                Minutes = 35,
                Seconds = 44,
                CourseId = courses[13].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Routing",
                Minutes = 36,
                Seconds = 51,
                CourseId = courses[13].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "What is OWIN?",
                Minutes = 18,
                Seconds = 57,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Building a Simple OWIN Pipeline",
                Minutes = 9,
                Seconds = 27,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Creating Middleware with OWIN",
                Minutes = 15,
                Seconds = 24,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Integrating Frameworks",
                Minutes = 20,
                Seconds = 10,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Securing OWIN Pipelines",
                Minutes = 17,
                Seconds = 32,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Integrating Social Media Authentication",
                Minutes = 16,
                Seconds = 58,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Hosting an OWIN Pipeline",
                Minutes = 12,
                Seconds = 32,
                CourseId = courses[14].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "SQL Injection",
                Minutes = 45,
                Seconds = 8,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Information Leakage",
                Minutes = 15,
                Seconds = 36,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Cross-Site Scripting (XSS)",
                Minutes = 71,
                Seconds = 0,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Parameter Tampering",
                Minutes = 29,
                Seconds = 3,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Encrypting and Hashing",
                Minutes = 45,
                Seconds = 34,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Cross-Site Request Forgery (CSRF)",
                Minutes = 38,
                Seconds = 36,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Denial of Service",
                Minutes = 17,
                Seconds = 49,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Session Management and Hijacking",
                Minutes = 37,
                Seconds = 24,
                CourseId = courses[15].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Introduction",
                Minutes = 13,
                Seconds = 20,
                CourseId = courses[16].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Creating Custom Controls",
                Minutes = 39,
                Seconds = 45,
                CourseId = courses[16].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Adding Properties",
                Minutes = 55,
                Seconds = 10,
                CourseId = courses[16].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Events and Commands",
                Minutes = 59,
                Seconds = 4,
                CourseId = courses[16].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Visual Behavior",
                Minutes = 37,
                Seconds = 36,
                CourseId = courses[16].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Theming",
                Minutes = 44,
                Seconds = 54,
                CourseId = courses[16].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Introduction",
                Minutes = 22,
                Seconds = 52,
                CourseId = courses[17].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Upgrading Your Application",
                Minutes = 38,
                Seconds = 51,
                CourseId = courses[17].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "New Features in Prism 5.0",
                Minutes = 50,
                Seconds = 2,
                CourseId = courses[17].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "MVVM",
                Minutes = 33,
                Seconds = 51,
                CourseId = courses[17].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Go Overview",
                Minutes = 26,
                Seconds = 2,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Go Development",
                Minutes = 31,
                Seconds = 32,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Variables, Types and Pointers",
                Minutes = 34,
                Seconds = 16,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Functions",
                Minutes = 29,
                Seconds = 33,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Branching",
                Minutes = 24,
                Seconds = 3,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Loops",
                Minutes = 18,
                Seconds = 12,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Maps",
                Minutes = 28,
                Seconds = 0,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Slices",
                Minutes = 19,
                Seconds = 46,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Methods and Interface",
                Minutes = 23,
                Seconds = 59,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Concurrency",
                Minutes = 40,
                Seconds = 20,
                CourseId = courses[18].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Job Interview Basics",
                Minutes = 30,
                Seconds = 17,
                CourseId = courses[19].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Algorithm Based Questions",
                Minutes = 34,
                Seconds = 43,
                CourseId = courses[19].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Typical Questions",
                Minutes = 24,
                Seconds = 10,
                CourseId = courses[19].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Computer Science Questions",
                Minutes = 34,
                Seconds = 10,
                CourseId = courses[19].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Getting Experience",
                Minutes = 23,
                Seconds = 58,
                CourseId = courses[19].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Overview and Console",
                Minutes = 35,
                Seconds = 3,
                CourseId = courses[20].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Elements Panel",
                Minutes = 33,
                Seconds = 24,
                CourseId = courses[20].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Resources and Network Panels",
                Minutes = 30,
                Seconds = 59,
                CourseId = courses[20].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Sources aned Network Panels",
                Minutes = 27,
                Seconds = 50,
                CourseId = courses[20].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Timeline and Profile Panels",
                Minutes = 42,
                Seconds = 56,
                CourseId = courses[20].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Objective-C Introduction",
                Minutes = 37,
                Seconds = 47,
                CourseId = courses[21].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Variables and Operators",
                Minutes = 39,
                Seconds = 31,
                CourseId = courses[21].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Classes",
                Minutes = 39,
                Seconds = 32,
                CourseId = courses[21].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Control Statements",
                Minutes = 39,
                Seconds = 27,
                CourseId = courses[21].CourseId
            });

            courseModules.Add(new CourseModule()
            {
                Title = "Inheritance and Polymorphism",
                Minutes = 32,
                Seconds = 19,
                CourseId = courses[21].CourseId
            });

            ICourseModuleRepository courseModuleRepository = new CourseModuleRepository();

            for (int i = 0; i < courseModules.Count; i++)
            {
                courseModules[i] = courseModuleRepository.Add(courseModules[i]);
                Console.WriteLine("Added course module '{0}'", courseModules[i].Title);
            }

            #endregion

            #region users

            Console.WriteLine();

            //List<User> users = new List<User>();

            //users.Add(new User()
            //{
            //    Login = "miguel",
            //    Password = "pluralsight1",
            //    FirstName = "Miguel",
            //    LastName = "Castro"
            //});

            //IUserRepository userRepository = new UserRepository();

            //for (int i = 0; i < users.Count; i++)
            //{
            //    users[i] = userRepository.Add(users[i]);
            //    Console.WriteLine("Added user '{0}'", users[i].Login);
            //}

            #endregion

            Console.WriteLine();
            Console.WriteLine("Seeding complete. Press [Enter] to exit.");
        }

        static void Test()
        {
            IAuthorRepository authorRepository = new AuthorRepository();

            IEnumerable<Author> authors = authorRepository.Get();
            int authorId = authors.ToList()[0].AuthorId;

            Author author = authorRepository.GetComplete(authorId);

            ICourseRepository courseRepository = new CourseRepository();

            IEnumerable<Course> courses = courseRepository.Get();
            int courseId = courses.ToList()[0].CourseId;

            Course course = courseRepository.GetComplete(courseId);

        }
    }
}
