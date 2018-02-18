Validating Form Submission

We need to apply the concepts of Models and Model validations that we learned from the past two tabs. Make a small app that runs validations on a variety of form fields. Use Data Annotations and Models to generate your error messages. Errors should be rendered for each field that submits invalid data. This app is a similar process to that of Dojo Survey just making sure to focus in on these new concepts!

Create a form that accepts the displayed fields

Build a User model (object) that reflects each of these fields with all proper validations

If any of the validations fail, redirecting back to the form page and displaying the relevant errors makes a lot of sense. However, do not spend too much time trying to get this to work.  Instead, it would be just as appropriate to load a new view from your Method that handles the form data.

If there are no errors, display a success page instead!