$("#regForm").validate({
    rules: {
        email: {
            required: true,
            email: true,
            remote: {
                url: "/Account/VerifyEmail?username=" + function () {
                    return $("#username").val();
                },
                type: "get",
            }
        }
    }
});