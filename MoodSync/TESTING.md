# MoodSync - Quick Testing Guide 🧪

## 🚀 **How to Run the App**

### **Step 1: Start the Application**
```powershell
cd MoodSync/MoodSyncApp
dotnet run
```

### **Step 2: Open in Browser**
The app runs on:
- **HTTPS**: https://localhost:7268 (recommended)
- **HTTP**: http://localhost:5178

## 🎯 **Feature Testing Checklist**

### **✅ Dashboard Testing**
**URL**: https://localhost:7268
**What to test:**
- [ ] Page loads with MoodSync branding
- [ ] "Today's Check-In" section shows current status
- [ ] "Friends' Weather" shows sample friend moods:
  - Sarah (😔 Sad - "Feeling a bit down")
  - Mike (😊 Happy - "Amazing weekend!")
  - Emma (😴 Tired - "Long week")
- [ ] Quick Stats show correct numbers
- [ ] Navigation menu is responsive

### **✅ Mood Check-In Testing**
**URL**: https://localhost:7268/mood-checkin
**What to test:**
- [ ] 5 mood buttons display correctly (😊😐😔😠😴)
- [ ] Clicking mood buttons shows active state
- [ ] Optional note field appears for non-neutral moods
- [ ] Character counter works (280 max)
- [ ] Submit button works
- [ ] Success confirmation appears
- [ ] "View Dashboard" and "Update Mood" buttons work
- [ ] Can update mood multiple times (replaces today's entry)

### **✅ Mood History Testing**
**URL**: https://localhost:7268/mood-history
**What to test:**
- [ ] Summary stats display correctly
- [ ] Mood distribution chart shows percentages
- [ ] Timeline shows historical entries
- [ ] "Days ago" labels are accurate
- [ ] Notes display properly in timeline
- [ ] Empty state shows when no history exists

### **✅ Navigation Testing**
**What to test:**
- [ ] All menu items work (Dashboard, Mood Check-In, My Mood History)
- [ ] Mobile menu toggle works (narrow browser)
- [ ] Page titles update correctly
- [ ] Active page highlights in navigation

## 🧪 **Sample Test Scenarios**

### **Scenario 1: New User Experience**
1. Go to Dashboard - should show "No check-in today"
2. Click "Check In Now" button
3. Select Happy mood (😊)
4. Add note: "Great day at work!"
5. Submit mood
6. Return to Dashboard - should show your mood
7. Go to Mood History - should show your entry

### **Scenario 2: Daily Update**
1. Go to Mood Check-In
2. Select different mood than before
3. Add different note
4. Submit - should replace previous entry
5. Verify Dashboard updates
6. Check Mood History shows updated entry

### **Scenario 3: Mobile Responsiveness**
1. Resize browser to mobile width (< 768px)
2. Test hamburger menu
3. Check all pages are readable
4. Verify mood buttons still work
5. Test form inputs on mobile

## 🎨 **Visual Elements to Check**

### **Emojis & Icons**
- [ ] Mood emojis render correctly: 😊😐😔😠😴
- [ ] Weather icons display: ☀️⛅🌧️⛈️🌫️
- [ ] Navigation icons work
- [ ] Page headers show emoji branding

### **Styling & Layout**
- [ ] Bootstrap components render properly
- [ ] Cards have proper spacing
- [ ] Buttons have hover effects
- [ ] Forms are properly aligned
- [ ] Colors and typography are consistent

## 🐛 **Common Issues to Check**

### **If the app won't start:**
- Make sure you're in the correct directory: `MoodSync/MoodSyncApp`
- Check if port 7268 is already in use
- Verify .NET 8.0 SDK is installed: `dotnet --version`

### **If pages don't load:**
- Check browser console for errors
- Verify HTTPS certificate is accepted
- Try HTTP version: http://localhost:5178

### **If data doesn't persist:**
- This is expected - we're using in-memory storage
- Data resets when app restarts
- This is perfect for demo purposes

## 🎯 **Demo Script**

### **1-Minute Demo Flow:**
1. **Dashboard**: "This is MoodSync - see today's check-in status and friends' moods"
2. **Check-In**: "Select your mood, add a note, submit"
3. **Dashboard**: "Now see your mood appears and stats update"
4. **History**: "View your mood history and analytics"
5. **Mobile**: "Fully responsive design"

### **Key Demo Points:**
- ✨ Simple, intuitive mood tracking
- 🌤️ Weather metaphor for emotional states
- 👥 Social aspect with friends' moods
- 📊 Personal analytics and insights
- 📱 Mobile-friendly design

## 🚀 **Next Steps After Testing**

If everything works perfectly:
1. **Database Integration** - Add PostgreSQL for persistence
2. **Authentication** - Add user login/registration
3. **Real Friends** - Add friend request system
4. **Real-time Updates** - Add SignalR for live updates
5. **Privacy Controls** - Add mood visibility settings

**Happy Testing!** 🎉
