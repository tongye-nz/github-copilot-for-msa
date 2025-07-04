# Workshop Step 5: Real-World Scenarios (20 minutes) 🔍⚙️

Solve common development tasks using GitHub Copilot and Copilot Chat in realistic workflows.

## Learning Objectives 🎯

- ✅ Use Copilot Chat to explain existing code and clarify intent
- ✅ Automatically generate unit tests for functions and modules
- ✅ Refactor code for improved readability, performance, and maintainability
- ✅ Adopt best practices in debugging and code review with AI assistance
- ✅ Confidently integrate Copilot into everyday development tasks

**Key mindset shift:** You’re the developer; Copilot is your pair-programmer and code reviewer.

---

## Part 1: Explaining Code (7 minutes)

**Context passing:**

I have this code snippet in `src/utils/math.js`:

```javascript
export function calculateAverage(nums) {
  const total = nums.reduce((sum, n) => sum + n, 0);
  return total / nums.length;
}
```

Can you explain what this function does, point out potential edge cases, and suggest improvements?

> **📸 SCREENSHOT NEEDED**: Copilot Chat explaining the code snippet and proposing enhancements

---

## Part 2: Generating Unit Tests (7 minutes)

**Prompt to Copilot Chat:**

```text
Please generate unit tests for `calculateAverage` using Jest. Cover normal cases, empty arrays, and invalid inputs.
```

Copilot should create a new test file at `tests/math.test.js` covering edge cases.

> **📸 SCREENSHOT NEEDED**: Generated unit tests demonstrating coverage of edge cases

---

## Part 3: Refactoring Code (6 minutes)

**Request for refactoring:**

Here is a module in `src/services/dataService.js`:

```javascript
export async function fetchData(endpoint) {
  try {
    const res = await fetch(endpoint);
    const json = await res.json();
    return json.data;
  } catch (error) {
    console.error(error);
    throw new Error('Data fetch failed');
  }
}
```

Can you refactor this code to improve error handling, add timeouts, and make it more testable?

> **📸 SCREENSHOT NEEDED**: Refactored `fetchData` with improved structure, timeouts, and dependency injection for testing

---

## Part 4: Real-Time Troubleshooting 🔧

**Missing testing library?**

```text
I don’t have Jest installed. Can you show me how to install it or provide an alternative using plain assertions?
```

**Tests failing?**

```text
Some of the generated tests are failing. Can you help diagnose why and update the tests or implementation?
```

**Large module refactor?**

```text
This file is too big. Can you suggest how to split it into smaller, single-responsibility modules?
```

> **📸 SCREENSHOT NEEDED**: Copilot providing alternative approaches and modular breakdowns

---

## Success Metrics & Next Steps 🎭

- [ ] Code explanations are clear and complete
- [ ] Generated tests cover edge cases and pass successfully
- [ ] Refactored code follows best practices and is maintainable
- [ ] Project files organized logically (`src/`, `tests/`)
- [ ] You understand how to leverage Copilot in daily workflows

**Immediate next steps:**

```bash
git add .
git commit -m "Completed real-world scenarios with Copilot"
git push origin feature/realworld-scenarios
```

---

**Congratulations!** 🎉 You’ve tackled real-world development scenarios with AI assistance. You're ready to apply these skills in your own projects.
