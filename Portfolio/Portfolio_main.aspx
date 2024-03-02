<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portfolio_main.aspx.cs" Inherits="Portfolio.Portfolio_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>My Portfolio</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="mediaqueries.css" />
    
    
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">
        <div class="logo">Asif Akbar</div>
        <div>
            <ul class="nav-links">
                <li><a href="#about">About</a></li>
                <li><a href="#experience">Experience</a></li>
                <li><a href="#projects">Projects</a></li>
                <li><a href="#contact">Contact</a></li>
            </ul>
        </div>
    </nav>
    <nav id="hamburger-nav">
        <div class="logo">Asif Akbar</div>
        <div class="hamburger-menu">
            <div class="hamburger-icon" onclick="toggleMenu()">
                <span></span>
                <span></span>
                <span></span>

            </div>
            <div>
            <div class="menu-links">
                <li><a href="#about" onclick="toggleMenu()">About</a></li>
                <li><a href="#experience" onclick="toggleMenu()">Experience</a></li>
                <li><a href="#projects" onclick="toggleMenu()">Projects</a></li>
                <li><a href="#contact" onclick="toggleMenu()">Contact</a></li>   
            </div>   
            </div>
        </div>
    </nav>
    <section id="profile">
        <div class="section__pic-container">
            <img src="./assets/profile pic original.png" alt="Asif Akbar Profile Picture" />
        </div>
        <div class="section__text">
            <p class="section__text__p1">Hello I'm</p>
            <h1 class="title">Asif Akbar</h1>
            <p class="section__text__p2">CS Undergrad</p>
            <div class="btn-container">
                <button class="btn btn-color-2" onclick="window.open('./assets/resume-example.pdf')">Download CV</button>
                
            </div>
            <div id="socials-container">
                <img src="./assets/linkedin.png" alt="My LinedIn Profile" class="icon" onclick="location.href='https://www.linkedin.com/in/asif-akbar-8153452b8/'" />
                <img src="./assets/github.png" alt="My GitHub Profile" class="icon" onclick="location.href='https://github.com/AsifAkbar106'" />
            </div>
        </div>
    </section>
    <section id="about">
        <p class="section__text__p1">Get To Know More</p>
        <h1 class="title">About Me</h1>
        <div class="section-container">
            <div class="section__pic-container">
                <img src="./assets/about me.png" alt="profile picture" class="about-pic" />
            </div>
            <div class="about-details-container">
                <div class="about-containers">
                    
                    <div class="details-container">
                        <img src="./assets/education.png" alt="Education Icon" class="icon" />
                        <h3>Education</h3>
                        <p>Studying BSc. in Computer Science and Engineering,KUET</p>
                        <p>Completed HSC at Notre Dame College,Dhaka</p>
                        <p>Completed SSC at Ideal School and College,Dhaka</p>
                    </div>
                </div>
                <div class="text-container">

                    <asp:Label ID="AboutMeLabel" cssClass="text-container" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
       
    </section>
    <section id="experience">
    <p class="section__text__p1">Explore My</p>
    <h1 class="title">Skills</h1>
    <div class="experience-details-container">
        <div class="about-containers">
        <div class="details-container">
            <h2 class="experience-sub-title">Frontend Development</h2>
            <div class="article-container" runat="server" id="frontendExperienceContainer">
                <!-- Frontend experience details will be dynamically added here -->
            </div>
        </div>
        <div class="details-container">
            <h2 class="experience-sub-title">Backend Development</h2>
            <div class="article-container" runat="server" id="backendExperienceContainer">
                <!-- Backend experience details will be dynamically added here -->
            </div>
        </div>
        </div>
    </div>
</section>
    <section id="projects">
        <p class="title">Projects</p>
        <div class="experience-details-container">

            <asp:Panel ID="projectsContainer" runat="server"></asp:Panel>
            
          
        </div>
        
        
    </section>
    <section id="contact">
        <p class="section__text__p1">Get in Touch</p>
        <h1 class="title">Contact Me</h1>
        <div class="contact-info-upper-container">
            <div class="contact-info-container">
                <img src="./assets/email.png" alt="E-mail Icon" class="icon contact-icon email-icon" />
                <p><a href="mailto:rirazon567@gmail.com">Example@gmail.com</a></p>

            </div>
            <div class="contact-info-container">
                <img src="./assets/linkedin.png" alt="LinkedIn Icon" class="icon contact-icon" />
                <p><a href="https://www.linkedin.com/in/asif-akbar-8153452b8/">LinkedIn</a></p>

            </div>
        </div>


    </section>


    
        
    <asp:Button ID="AdminButton" runat="server" Text="Admin" CssClass="admin-button" OnClick="AdminButton_Click" />
    

    <footer>
        <nav>
            <div class="nav-links-container">
                <ul class="nav-links">
                    <li><a href="#about">About</a></li>
                    <li><a href="#experience">Experience</a></li>
                    <li><a href="#projects">Projects</a></li>
                    <li><a href="#contact">Contact</a></li>
                </ul>
            </div>

        </nav>
        <p>Copyright &#169; 2024 by Asif Akbar.All Rights Reserved.</p>
    </footer>


    <script src="script.js"></script>

    </form>
</body>
</html>
