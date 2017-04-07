using System;
using System.Data;
using System.Linq;
using WebServiceHost.Database;
using WebServiceHost.Entities;

namespace TestingEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MainDbContext ctx = new MainDbContext())
            {
                try
                {
                    registerTest(ctx);
                    int loggedInUserId = loginTest(ctx);

                    var addedSiteId = adminAddNewSite(ctx);
                    var addedRequestId = adminAddNewProductRequest(ctx, addedSiteId);
                    addUserRequestProductAssignment(ctx, loggedInUserId, addedRequestId);
                    cancelProductRequest(ctx, addedRequestId);
                    //cleanUp(ctx);
                }
                catch (Exception e)
                {
                    cleanUp(ctx);
                    Console.WriteLine("Testing failed: {0}", e.Message);
                }

            }
        }

        static void cleanUp(MainDbContext ctx)
        {
            using (var connection = ctx.Database.Connection)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (var cleanupCommand = connection.CreateCommand())
                {
                    cleanupCommand.CommandText = "TRUNCATE TABLE public.delivery_locations RESTART IDENTITY CASCADE";
                    cleanupCommand.ExecuteNonQuery();
                }
                using (var cleanupCommand = connection.CreateCommand())
                {
                    cleanupCommand.CommandText = "TRUNCATE TABLE public.login_info RESTART IDENTITY CASCADE";
                    cleanupCommand.ExecuteNonQuery();
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        static void registerTest(MainDbContext ctx)
        {
            try
            {
                LoginInfo loginInfo = new LoginInfo();
                loginInfo.Username = "antochsi";
                loginInfo.Password = "parolameasmechera";

                UserInfo userInfo = new UserInfo();
                userInfo.FirstName = "Silviu";
                userInfo.LoginInfo = loginInfo;

                ctx.UserInfo.Add(userInfo);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Register failure: " + e.Message);
            }
        }

        static int loginTest(MainDbContext ctx)
        {
            var shouldBeNull = ctx.LoginInfo.FirstOrDefault(li => li.Username == "NonExisting" && li.Password == "noimportance");
            if (shouldBeNull != null)
                throw new Exception("Login failure: found a non-existing user");
            shouldBeNull = ctx.LoginInfo.FirstOrDefault(li => li.Username == "antochsi" && li.Password == "wrong");
            if (shouldBeNull != null)
                throw new Exception("Login failure: found user with wrong password");
            var goodUser = ctx.LoginInfo.FirstOrDefault(li => li.Username == "antochsi" && li.Password == "parolameasmechera");
            if (goodUser == null)
                throw new Exception("Login failure: right credentials, no user found");

            return goodUser.ID;
        }

        static int adminAddNewSite(MainDbContext ctx)
        {
            try
            {
                DeliverySite site = new DeliverySite();
                site.Name = "Sacele";
                site.Address = "Bunloc 1, Sediu CIBIN";

                ctx.DeliverySites.Add(site);
                ctx.SaveChanges();

                return site.ID;
            }
            catch (Exception e)
            {
                throw new Exception("Site add failure: " + e.Message);
            }
        }

        static int adminAddNewProductRequest(MainDbContext ctx, int siteId)
        {
            try
            {
                ProductRequest request = new ProductRequest();
                request.Item = "Mancare";

                try
                {
                    ctx.ProductRequests.Add(request);
                    ctx.SaveChanges();
                    throw new Exception("Product request add failure: added request with no site attached");
                }
                catch { }

                var existingSite = ctx.DeliverySites.FirstOrDefault(site => site.ID == siteId);
                if (existingSite == null)
                    throw new Exception("Product request add failure: existing site not found by ID");

                request.DeliverySite = existingSite;
                ctx.ProductRequests.Add(request);
                ctx.SaveChanges();

                return request.ID;
            }
            catch (Exception e)
            {
                throw new Exception("Product request add failure: " + e.Message);
            }
        }

        static void addUserRequestProductAssignment(MainDbContext ctx, int userId, int requestId)
        {
            try
            {
                var existingUser = ctx.UserInfo.FirstOrDefault(ui => ui.ID == userId);
                if (existingUser == null)
                    throw new Exception("Assignment add failure: existing user not found by ID");

                var existingRequest = ctx.ProductRequests.FirstOrDefault(pr => pr.ID == requestId);
                if (existingRequest == null)
                    throw new Exception("Assignment add failure: existing request not found by ID");

                UserProductRequestAssigment assignment = new UserProductRequestAssigment();
                assignment.User = existingUser;
                assignment.ProductRequest = existingRequest;

                ctx.RequestAssignments.Add(assignment);
                ctx.SaveChanges();
            }
            catch
            {
                throw new Exception("Assignment add failure: could not add assignment");
            }
        }

        static void cancelProductRequest(MainDbContext ctx, int requestId)
        {
            try
            {
                var existingProductRequest = ctx.ProductRequests.FirstOrDefault(pr => pr.ID == requestId);
                if (existingProductRequest == null)
                    throw new Exception("Cancel product request failure: existing request not found by ID");

                var associatedSiteId = existingProductRequest.DeliverySite.ID;
                var associatedUserId = existingProductRequest.RequestAssignment.UserId;
                try
                {
                    ctx.ProductRequests.Remove(existingProductRequest);
                    ctx.SaveChanges();
                }
                catch
                {
                    throw new Exception("Cancel product request failure: failed to remove existing product request");
                }

                var previouslyAssignedSite = ctx.DeliverySites.FirstOrDefault(site => site.ID == associatedSiteId);
                if (previouslyAssignedSite == null)
                    throw new Exception("Cancel product request failure: associated site was wrongly deleted");

                var previouslyAssignedUser = ctx.UserInfo.FirstOrDefault(user => user.ID == associatedUserId);
                if (previouslyAssignedUser == null)
                    throw new Exception("Cancel product request failure: associated user was wrongly deleted");

                int requestAssignmentCount = ctx.RequestAssignments.Count();
                if (requestAssignmentCount != 0)
                    throw new Exception("Cancel product request failure: associated request assignment not deleted");
            }
            catch
            {
                throw new Exception("Cancel product request failure: Unknown error");
            }
        }

    }
}
// Register: Add new LoginInfo and UserInfo
// Login: Get user

// Admin: add new site
// Admin: add new product request for site
// Admin: cancel product request