package com.example.dre.individualprojectlussarv11;


import java.util.ArrayList;


/***
 * @Author Andre Lussier
 *
 * this is both the M and C in MVC model
 * because of such limited resources used was bit extraneous to separate M and C
 *
 * validation forces them to be entered together so they will correctly index together
 * aka parellel ArrayLists
 * mUsers is a list of usersnames
 * mPasswords is a list of passwords
 * mFirstName is a list of first names
 * mLastName is a list of last names
 * mDOB is a list of date of births
 * mEmail is a list of emails
 *
 * validatelogin makes sure username and pass arent blank
 * then checks if user name is in list then compares that username
 * to the password
 *
 * addUser checks if username and pass have length and exist
 * then makes sure the username they're trying to add is not already in the arraylist
 * after all that it will add
 *
 * validNonBlank just return t/f after checking if the entire form is blank or
 *
 * validNames valid names will check validation on both first and last name
 * has looser coupling than other methods
 *
 * validEmail checks if . and @ are in the values does not map out to a real email
 *
 * validUnPass checks length validation of username and pass
 *
 * addAccount checks of of the form information at once
 * it calls most of the other methods and will only add the data
 * to the arraylists if it meets all credentials
 */

public class LoginBackend {



    private static ArrayList<String> mUsers = new ArrayList<String>(10);
    private static ArrayList<String> mPasswords = new ArrayList<String>(10);
    private static ArrayList<String> mFirstName = new ArrayList<String>(10);
    private static ArrayList<String> mLastName = new ArrayList<String>(10);
    private static ArrayList<String> mDOB = new ArrayList<String>(10);
    private static ArrayList<String> mEmail = new ArrayList<String> (10);

    /***
     *
     * @param u is username
     * @param p is password
     * @return true false if valid login
     */


    public boolean validateLogin(String u, String p){

        if(u.equals(""))
        {
            return false;
        }

        if(p.equals(""))
        {
            return false;
        }

        if(mUsers.contains(u)) {
            int user_location = mUsers.indexOf(u);
            if (p.equals(mPasswords.get(user_location)))
            {
                return true;
            }

        }

        return false;
    }

    /***
     *
     * @param u username as a string
     * @param p password as a string
     * @return true if user added false otherwise
     */


    public boolean addUser(String u, String p){

        if(u.equals(""))
        {
            return false;
        }

        if(p.equals(""))
        {
            return false;
        }

        if(p.length() < 6)
        {
            return false;
        }

        if(mUsers.contains(u)){
            return false;
        }
        else
        {
            mUsers.add(u);
            mPasswords.add(p);
            return true;
        }
    }

    /***
     *
     * @param u username as string
     * @param p password as string
     * @param fn first name as string
     * @param ln last name as string
     * @param em email as string
     * @param uDOB Date of Birth as string no formatting
     * @return true for no blanks false otherwise
     */

    public boolean validNonBlank(String  u, String p, String fn, String ln, String em, String uDOB)
    {
        if(u.equals(""))
        {
            return false;
        }

        if(p.equals(""))
        {
            return false;
        }

        if(fn.equals(""))
        {
            return false;
        }

        if(ln.equals(""))
        {
            return false;
        }

        if(em.equals(""))
        {
            return false;
        }

        if(uDOB.equals(""))
        {
            return false;
        }

        return true;
    }

    /***
     *
     * @param n name, either first or last is valid
     * @return true if valid name false otherwise
     */

    public boolean validNames(String n){

        if(n.length() < 4)
        {
            return false;
        }

        if(n.length() > 30)
        {
            return false;
        }

        return true;
    }

    /***
     *
     * @param em email as a string
     * @return true if valid email false otherwise
     */

    public boolean validEmail(String em)
    {
        if(em.length() < 6)
        {
            return  false;
        }

        if(em.length() > 70)
        {
            return false;
        }

        if(!em.contains("@"))
        {
            return false;
        }

        if(!em.contains("."))
        {
            return false;
        }

        return true;
    }

    /***
     *
     * @param u username as a string
     * @param p password as a string
     * @return returns true if valid password false otherwise
     */

    public boolean validUnPass(String u, String p)
    {
        if(u.length() < 4)
        {
            return false;
        }

        if(p.length() < 4)
        {
            return false;
        }

        if(u.length() > 20)
        {
            return false;
        }

        if(p.length() > 20)
        {
            return false;
        }

        if(p.equals(p.toLowerCase())){
            return false;
         }


        return true;
    }

    /***
     * This method will only allow you to add a user/ data if all
     * the checks are passed at once
     * this maintains the parelle arraylists
     * @param u username as a string
     * @param p password as a string
     * @param fn first name as a string
     * @param ln last name as a string
     * @param em email as a string
     * @param dob date of birth as a string * does not contain formatting
     * @return returns true if all checks are passed and a user was added
     *
     */

    public boolean addAccount(String u, String p, String fn, String ln, String em, String dob)
    {
        if(validNonBlank(u,p,fn,ln,dob,em))
        {
            if(validUnPass(u, p) && validNames(fn) && validNames(ln) && validEmail(em)) { //) && addUser(u, p)

                if (addUser(u, p))// adds to both Users and mPassword
                {
                    mFirstName.add(fn); // add user works something in validation is broken
                    mLastName.add(ln);
                    mDOB.add(dob);
                    mEmail.add(em);
                    return true;
                }
            }
        }

        return false;
    }

}
