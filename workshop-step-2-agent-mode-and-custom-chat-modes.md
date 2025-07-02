# Workshop Step 2: Agent Mode & Custom Chat Modes (30 minutes) 🤖💬

Welcome to the exciting world of AI-powered development! In this step, you'll learn how to work with GitHub Copilot's advanced features to brainstorm and refine your app idea.

## Learning Objectives 🎯

By the end of this section, you will:

- ✅ Understand how to use GitHub Copilot in Agent Mode
- ✅ Work with custom chat modes for idea generation
- ✅ Collaborate with AI to refine your application concept
- ✅ Make informed technology stack decisions

## Prerequisites Check ✅

Before we begin, ensure you have:

- [ ] Forked this repository to your GitHub account
- [ ] GitHub Copilot enabled in VS Code
- [ ] GitHub Copilot Chat extension installed and activated

## Part 1: Repository Setup (5 minutes) 🔧

### Step 1: Fork the Repository

1. Navigate to the main repository: `https://github.com/PlagueHO/github-copilot-for-msa`
2. Click the **Fork** button in the top-right corner
3. Select your GitHub account as the destination
4. Wait for the fork to complete

### Step 2: Clone Your Fork

1. Open your terminal/command prompt
2. Run the following command (replace `<your-username>` with your GitHub username):

   ```bash
   gh repo clone <your-username>/github-copilot-for-msa
   ```

3. Navigate to the cloned directory:

   ```bash
   cd github-copilot-for-msa
   ```

4. Open the project in VS Code:

   ```bash
   code .
   ```

## Part 2: Understanding Agent Mode (5 minutes) 🕵️‍♂️

### What is Agent Mode?

Agent Mode in GitHub Copilot allows you to work with AI as a collaborative partner that can:

- Take autonomous actions to solve complex problems
- Create multiple files and make coordinated changes
- Follow multi-step workflows
- Provide end-to-end solutions

### Key Features

- **Autonomous Problem Solving**: Copilot can break down complex tasks
- **Multi-file Operations**: Create and modify multiple files simultaneously
- **Context Awareness**: Understands your entire project structure
- **Iterative Refinement**: Continuously improves solutions based on feedback

### Activating Agent Mode

1. Open the Command Palette (`Ctrl+Shift+P` / `Cmd+Shift+P`)
2. Type "GitHub Copilot: Enable Agent Mode"
3. Or look for the agent icon in the Copilot Chat panel

## Part 3: Working with Custom Chat Modes (10 minutes) 💭

### Understanding Chat Modes

Custom chat modes are specialized AI assistants designed for specific tasks. Think of them as expert consultants for different aspects of development.

### Available Chat Modes

#### 1. `simple_app_idea_generator` 💡

**Purpose**: Helps you brainstorm and develop initial app concepts
**When to use**: When you need creative inspiration or want to explore different app ideas
**How it helps**:

- Generates unique app concepts based on your interests
- Considers market trends and feasibility
- Provides initial feature suggestions

#### 2. `mentor` 👨‍🏫

**Purpose**: Acts as an experienced developer mentor
**When to use**: When you need guidance on technical decisions or want to refine your ideas
**How it helps**:

- Reviews your app concept for feasibility
- Suggests appropriate technology stacks
- Provides best practices and recommendations
- Helps identify potential challenges

### How to Access Chat Modes

1. Open the GitHub Copilot Chat panel (usually on the left sidebar)
2. Type `@` followed by the chat mode name (e.g., `@simple_app_idea_generator`)
3. Follow the prompts and engage in conversation

## Part 4: Hands-On Exercise - Develop Your App Idea (10 minutes) 🚀

### Exercise 1: Generate Your App Idea (5 minutes)

1. **Open Copilot Chat** and start a conversation with the idea generator:

   ```text
   @simple_app_idea_generator
   
   I'm interested in building an app that helps solve everyday problems. 
   I have experience with [mention your programming languages/frameworks].
   I'm particularly interested in [mention areas like social networking, productivity, health, education, etc.].
   
   Can you help me brainstorm some unique app ideas?
   ```

2. **Engage with the suggestions**:

   - Ask follow-up questions about ideas that interest you
   - Request more details about implementation complexity
   - Explore different variations of promising concepts

3. **Document your favorite ideas** in a new file:

   - Create `my-app-ideas.md` in your project root
   - List your top 3 app concepts with brief descriptions

### Exercise 2: Refine with the Mentor (5 minutes)

1. **Switch to the mentor chat mode**:

   ```text
   @mentor
   
   I've been working with the idea generator and I'm considering these app concepts:
   [paste your top 3 ideas]
   
   Can you help me evaluate these ideas and suggest the best technology stack for implementation?
   ```

2. **Key questions to ask the mentor**:
   - "Which idea has the best balance of innovation and feasibility?"
   - "What technology stack would you recommend for [chosen idea]?"
   - "What are the main technical challenges I should be aware of?"
   - "How would you approach the user experience for this app?"

3. **Make your final decision**:
   - Choose your primary app concept
   - Note the recommended technology stack
   - Identify 3-5 core features to focus on

## Tips for Success 💡

### Working Effectively with AI

- **Be specific**: The more context you provide, the better the AI can help
- **Ask follow-up questions**: Don't hesitate to dig deeper into suggestions
- **Iterate**: Use the conversation to refine and improve ideas
- **Think practically**: Consider your skill level and time constraints

### Common Pitfalls to Avoid

- ❌ Being too vague in your requests
- ❌ Not providing enough context about your experience level
- ❌ Choosing overly complex ideas for a workshop setting
- ❌ Ignoring the mentor's technical guidance

## Expected Outcomes 📋

By the end of this step, you should have:

- [ ] Successfully forked and cloned the repository
- [ ] A clear understanding of how Agent Mode works
- [ ] Experience using custom chat modes
- [ ] A well-defined app concept
- [ ] A recommended technology stack
- [ ] 3-5 core features identified for your app

## Next Steps 🔄

In the next workshop step, you'll use prompt files to:

1. Create a detailed specification for your app
2. Develop a comprehensive implementation plan
3. Get final mentor review and approval

## Troubleshooting 🔧

### Common Issues and Solutions

**Problem**: Chat modes not responding
**Solution**: Ensure GitHub Copilot Chat extension is enabled and you're signed into GitHub

**Problem**: Can't access custom chat modes
**Solution**: Update your VS Code and GitHub Copilot extensions to the latest versions

**Problem**: Getting generic responses
**Solution**: Provide more specific context about your goals, experience level, and preferences

**Problem**: Overwhelmed by too many suggestions
**Solution**: Focus on one idea at a time and ask the mentor to help prioritize

## Additional Resources 📚

- [GitHub Copilot Chat Documentation](https://docs.github.com/en/copilot/chat)
- [VS Code Copilot Setup Guide](https://code.visualstudio.com/docs/copilot/setup)
- [Best Practices for AI-Assisted Development](https://docs.github.com/en/copilot/using-github-copilot/best-practices-for-using-github-copilot)

---

**Ready for the next step?** Once you've completed this section, proceed to [Workshop Step 3: Prompt Files](workshop-step-3-prompt-files.md) to create your detailed app specification! 🚀
