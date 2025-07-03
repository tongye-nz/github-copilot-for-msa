# Workshop Step 3: Prompt Files (30 minutes) 📝✨

Learn to create structured specifications and implementation plans using GitHub Copilot's prompt files.

## Learning Objectives 🎯

- ✅ Understand prompt files and their power for structured AI guidance
- ✅ Create comprehensive app specification using `/create_spec`
- ✅ Develop detailed implementation plan using `/create_plan`
- ✅ Conduct final review with mentor chat mode

## What Are Prompt Files 🤔

**Prompt files** = Specialized, reusable templates that provide structured AI guidance for specific tasks.

**Benefits:**

- **Consistency**: Every specification follows the same high-quality structure
- **Completeness**: Nothing important gets missed
- **Efficiency**: Faster than manual documentation
- **Professional Quality**: Industry-standard outputs

**How they work:**

1. Invoke with forward slash (e.g., `/create_spec`)
2. AI asks targeted questions about your project
3. Generate comprehensive documentation based on answers
4. Iterate and refine outputs as needed

## Part 1: Available Prompt Files (5 minutes) 📖

**Application Specification Generator (`/create_spec`)**

Produces: Feature requirements, technical architecture, UX guidelines, database schema, API specs, security considerations

**Implementation Plan Generator (`/create_plan`)**

Produces: Project timeline, development phases, file structure, setup instructions, testing strategy, deployment considerations

> **📸 SCREENSHOT NEEDED**: Copilot Chat showing /create_spec command autocomplete

## Part 2: Creating Your App Specification (15 minutes) 📋

### Step 1: Invoke the Specification Prompt (2 minutes)

1. **Open GitHub Copilot Chat**
2. **Type:** `/create_spec`
3. **Be prepared to share:**
   - Your app idea from Step 2
   - Target audience and core features
   - Technology preferences
   - Any specific requirements

> **📸 SCREENSHOT NEEDED**: /create_spec prompt starting conversation with initial questions

### Step 2: Work Through the Questions (8 minutes)

**Example interaction:**

```text
You: /create_spec

Copilot: I'll help you create a comprehensive specification. Let's start:
1. What is your app's name and primary purpose?

You: My app is called "FaceLink" - it's like Shazam but for people. It uses smart glasses with voice activation to discretely identify people and provide context about them.

Copilot: Excellent concept! Now let's dive deeper...
```

**Key areas covered:**

- App overview (purpose, audience, problem solved, unique value)
- Feature requirements (MVP vs. future features, user interactions, data handling)  
- Technical requirements (platforms, real-time needs, integrations, performance)

> **📸 SCREENSHOT NEEDED**: Example specification output showing structured sections

### Step 3: Review and Refine (5 minutes)

**Ask for clarifications:**

```text
Can you expand on the privacy and security considerations section?
Can you add more detail about the smart glasses integration?
What about offline capabilities?
```

**Save your work:**

- Copy output to `app-specification.md`
- Commit to your repository

## Part 3: Creating Your Implementation Plan (10 minutes) 🗺️

### Step 1: Generate Implementation Plan (3 minutes)

**Start the planning process:**

```text
/create_plan

Based on the specification we just created for FaceLink, 
please create a detailed implementation plan.
```

> **📸 SCREENSHOT NEEDED**: /create_plan command in action with project context provided

### Step 2: Work Through Planning Questions (5 minutes)

**Key areas covered:**

- **Project Structure**: Codebase organization, files/folders, component structure
- **Development Phases**: Build order (MVP first), feature prioritization, key milestones  
- **Technical Setup**: Development environment, dependencies, project configuration
- **Testing & Deployment**: Testing approach, deployment strategy, CI/CD considerations

### Step 3: Refine the Plan (2 minutes)

**Ask for specific clarifications:**

```text
Can you break down Phase 1 into smaller, daily tasks?
What specific libraries should I use for face recognition?
How should I handle the smart glasses API integration?
```

**Save your work:**

- Copy to `implementation-plan.md`
- Commit to repository

> **📸 SCREENSHOT NEEDED**: Example implementation plan showing phased development approach

## Part 4: Final Review with Mentor (5 minutes) 👨‍🏫

**Engage mentor for comprehensive review:**

```text
@mentor

I've created a specification and implementation plan for my app. 
Can you review both documents and provide feedback on:

1. Technical feasibility for a 90-minute workshop
2. Any missing critical components  
3. Potential risks or challenges
4. Recommendations for simplification if needed

[Paste your specification and plan]
```

**Expected mentor feedback:**

- ✅ Validate technical feasibility
- ✅ Identify potential simplifications
- ✅ Suggest alternative approaches if needed
- ✅ Confirm tech stack choices
- ✅ Highlight critical path items

> **📸 SCREENSHOT NEEDED**: Mentor providing technical review and recommendations

## Expected Outcomes & Next Steps 📋

**By the end of this step, you should have:**

- [ ] Complete app specification document (`app-specification.md`)
- [ ] Detailed implementation plan (`implementation-plan.md`)  
- [ ] Mentor validation of your approach
- [ ] Clear understanding of what you'll build
- [ ] Ready-to-execute development plan

**Quick Troubleshooting:**

- **Prompt files not working?** → Update VS Code and Copilot extensions, try fresh chat session
- **Generic/incomplete outputs?** → Provide more specific context, ask targeted follow-up questions
- **Technical concerns?** → Always validate complex decisions with mentor, ask for simpler alternatives

---

**Ready to build?** Proceed to [Workshop Step 4: Build Your Application](workshop-step-4-build-your-application.md) to see your app come to life! 🚀
