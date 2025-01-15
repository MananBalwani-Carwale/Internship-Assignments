function togglePassword(id,iconId)
{
    var password = document.getElementById(id);
    var icon = document.getElementById(iconId);
    if(password.type == "password")
    {
        password.type = "text";
        icon.src= "icons/eye-solid.svg"
    }
    else
    {
        password.type = "password";
        icon.src= "icons/eye-slash-solid.svg"
    }
}
function validateUsername()
{
    var result = true;
    var username = document.getElementById("username");
    if(username.value.length < 3 || username.value.length > 25)
    {
        result = false;
        document.getElementById("username-error").innerHTML = "Username must be between 3 and 25 characters";
        document.getElementById("username").setAttribute("class", "input username username-invalid");
    }
    else
    {
        document.getElementById("username-error").innerHTML = "";
        document.getElementById("username").setAttribute("class", "input username username-valid");
    } 
    return result;
}
function validateEmail()
{
    var result = true;
    var email = document.getElementById("email").value;
    if(email.length == 0 || email.indexOf('@') == -1)
    {
        result = false;
        document.getElementById("email-error").innerHTML = "Invalid Email";
        document.getElementById("email").setAttribute("class","input email email-invalid");
    }
    else
    {
        document.getElementById("email-error").innerHTML = "";
        document.getElementById("email").setAttribute("class","input email email-valid");
    }
    return result;
}
function validatePassword()
{
    var result = true;
    var password = document.getElementById("password").value;
    var regexp = new RegExp("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*])*");
    if(password.length < 8 || (regexp.test(password) == false))
    {
        result = false;
        document.getElementById("password-error").innerHTML = "Password must have atleast 8 characters that must include at least 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character in (!@#$%^&*)";
        document.getElementById("password").setAttribute("class", "input password confirm-password-invalid");
    }
    else
    {
        document.getElementById("password-error").innerHTML = "";
        document.getElementById("password").setAttribute("class", "input password confirm-password-valid");
    }
    return result;
}
function validateConfirmPassword()
{
    var result = true;
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword");
    var confirmPasswordValue = confirmPassword.value;
    if(password === confirmPasswordValue)
    {
        document.getElementById("confirm-password-error").innerHTML = "";
        confirmPassword.setAttribute("class", "input confirm-password confirm-password-valid");
    }
    else
    {
        result = false;
        document.getElementById("confirm-password-error").innerHTML = "Please Enter the password again";
        confirmPassword.setAttribute("class", "input confirm-password confirm-password-invalid");
    }
    return result;
}
function submitForm()
{
    event.preventDefault();
    var email = validateEmail();
    var password = validatePassword();
    var username = validateUsername();
    var confirmPassword = validateConfirmPassword();
    if(email && password && username && confirmPassword)
    {
        alert("You are Signed Up");
    }
}