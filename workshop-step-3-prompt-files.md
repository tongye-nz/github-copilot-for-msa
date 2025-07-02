# Workshop Step 3: Prompt Files (30 minutes) 📝✨

Welcome to the world of prompt engineering! In this step, you'll learn how to create structured specifications and implementation plans using GitHub Copilot's powerful prompt files feature.

## Learning Objectives 🎯

By the end of this section, you will:

- ✅ Understand what prompt files are and why they're powerful
- ✅ Create a comprehensive app specification using `/create_spec`
- ✅ Develop a detailed implementation plan using `/create_plan`
- ✅ Conduct a final review with the mentor chat mode
- ✅ Have production-ready documentation for your app

## What Are Prompt Files? 🤔

Prompt files are specialized, reusable templates that provide structured guidance to AI for specific tasks. Think of them as:

- **Expert consultants** for different development phases
- **Structured frameworks** that ensure comprehensive coverage
- **Quality gates** that maintain consistency and completeness
- **Best practice templates** that incorporate industry standards

### Key Benefits

- **Consistency**: Every specification follows the same high-quality structure
- **Completeness**: Nothing important gets missed
- **Efficiency**: Faster than manual documentation
- **Professional Quality**: Industry-standard outputs

## Part 1: Understanding the Prompt Files (5 minutes) 📖

### Available Prompt Files

#### `/create_spec` - Application Specification Generator

**Purpose**: Creates comprehensive technical specifications for your application
**What it produces**:

- Detailed feature requirements
- Technical architecture overview
- User experience guidelines
- Database schema (if applicable)
- API specifications
- Security considerations
- Performance requirements

#### `/create_plan` - Implementation Plan Generator

**Purpose**: Creates step-by-step development roadmaps
**What it produces**:

- Project timeline and milestones
- Development phases breakdown
- File structure and organization
- Technology setup instructions
- Testing strategy
- Deployment considerations

### How Prompt Files Work

1. You invoke them with a forward slash (e.g., `/create_spec`)
2. They ask targeted questions about your project
3. Based on your answers, they generate comprehensive documentation
4. You can iterate and refine the outputs

## Part 2: Creating Your App Specification (15 minutes) 📋

### Step 1: Invoke the Specification Prompt (2 minutes)

1. **Open GitHub Copilot Chat**
2. **Start the specification process**:

   ```text
   /create_spec
   ```

3. **Provide your app context**:
   The prompt will ask for details about your app. Be prepared to share:
   - Your app idea from Step 2
   - Target audience
   - Core features
   - Technology preferences
   - Any specific requirements

### Step 2: Work Through the Specification Questions (8 minutes)

The `/create_spec` prompt will guide you through several key areas:

#### App Overview Questions

- What is your app's primary purpose?
- Who is your target audience?
- What problem does it solve?
- What makes it unique?

#### Feature Requirements

- What are the core features (MVP)?
- What are nice-to-have features (future versions)?
- How will users interact with your app?
- What data will your app handle?

#### Technical Requirements

- What platforms will you support? (Web, mobile, desktop)
- Do you need real-time features?
- What integrations are required?
- Are there specific performance requirements?

#### Example Interaction

```text
You: /create_spec

Copilot: I'll help you create a comprehensive specification for your app. Let's start:

1. What is your app's name and primary purpose?

You: My app is called "FaceLink" - it's like Shazam but for people. It uses smart glasses with voice activation to discretely identify people and provide context about them.

Copilot: Excellent concept! Now let's dive deeper...
[Continues with targeted questions]
```

### Step 3: Review and Refine the Specification (5 minutes)

1. **Read through the generated specification carefully**
2. **Ask for clarifications or additions**:

   ```text
   Can you expand on the privacy and security considerations section?
   Can you add more detail about the smart glasses integration?
   What about offline capabilities?
   ```

3. **Save your specification**:
   - Copy the output to a new file called `app-specification.md`
   - Commit this to your repository

## Part 3: Creating Your Implementation Plan (10 minutes) 🗺️

### Step 1: Generate Your Implementation Plan (3 minutes)

1. **Start a new chat or continue the existing one**:

   ```text
   /create_plan
   ```

2. **Reference your specification**:

   ```text
   Based on the specification we just created for FaceLink, 
   please create a detailed implementation plan.
   ```

### Step 2: Work Through the Planning Questions (5 minutes)

The `/create_plan` prompt will cover:

#### Project Structure

- How should the codebase be organized?
- What files and folders are needed?
- How should components be structured?

#### Development Phases

- What should be built first (MVP)?
- How should features be prioritized?
- What are the key milestones?

#### Technical Setup

- What development environment is needed?
- What dependencies should be installed?
- How should the project be configured?

#### Testing and Deployment

- What testing approach should be used?
- How will the app be deployed?
- What CI/CD considerations are there?

### Step 3: Refine the Plan (2 minutes)

1. **Ask for specific clarifications**:

   ```text
   Can you break down Phase 1 into smaller, daily tasks?
   What specific libraries should I use for face recognition?
   How should I handle the smart glasses API integration?
   ```

2. **Save your implementation plan**:
   - Copy to `implementation-plan.md`
   - Commit to your repository

## Part 4: Final Review with Mentor (5 minutes) 👨‍🏫

### Conduct a Comprehensive Review

1. **Engage the mentor chat mode**:

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

### Key Review Questions

- "Is this scope appropriate for a workshop setting?"
- "Are there any technical red flags I should be aware of?"
- "What would you prioritize if we had limited time?"
- "Are there any dependencies that could cause problems?"

### Expected Mentor Feedback

The mentor should help you:

- ✅ Validate technical feasibility
- ✅ Identify potential simplifications
- ✅ Suggest alternative approaches if needed
- ✅ Confirm your tech stack choices
- ✅ Highlight critical path items

## Quality Checklist ✅

Before moving to the next step, ensure your documentation includes:

### Specification Document

- [ ] Clear app description and purpose
- [ ] Defined target audience
- [ ] Comprehensive feature list (MVP vs. future)
- [ ] Technical architecture overview
- [ ] Data models and schemas
- [ ] API specifications (if applicable)
- [ ] Security and privacy considerations
- [ ] Performance requirements
- [ ] User experience guidelines

### Implementation Plan

- [ ] Project structure and file organization
- [ ] Development phases with clear milestones
- [ ] Technology setup instructions
- [ ] Step-by-step build process
- [ ] Testing strategy
- [ ] Deployment considerations
- [ ] Risk mitigation strategies

## Tips for Success 💡

### Getting Better Outputs

- **Be specific**: Provide detailed context about your app idea
- **Ask follow-up questions**: Don't settle for generic responses
- **Iterate**: Use the conversation to refine and improve
- **Think practically**: Consider workshop time constraints

### Working with Prompt Files

- **Trust the process**: Let the prompts guide you through comprehensive planning
- **Provide context**: Reference your previous work and decisions
- **Ask for examples**: Request specific code snippets or configuration examples
- **Validate assumptions**: Use the mentor to double-check technical decisions

## Common Challenges and Solutions 🔧

### Challenge: Specification too complex for workshop

**Solution**: Ask mentor to suggest MVP version focusing on core features

### Challenge: Implementation plan too detailed

**Solution**: Request a "workshop-focused" version with simplified steps

### Challenge: Technology stack concerns

**Solution**: Ask mentor for alternative technologies that are easier to set up

### Challenge: Missing critical details

**Solution**: Use follow-up questions to fill gaps in specific areas

## Sample Outputs 📄

### Example Specification Section

```markdown
## Core Features (MVP)
1. **Voice Activation**: "Who is that?" command triggers identification
2. **Face Recognition**: Computer vision to identify individuals
3. **Contact Integration**: Links to personal contact database
4. **Discrete Display**: Minimal HUD overlay in smart glasses
5. **Privacy Controls**: Opt-in system for adding new contacts

## Technical Architecture
- **Frontend**: React Native app for smart glasses
- **Backend**: Node.js API with Express
- **Database**: SQLite for local contact storage
- **AI/ML**: TensorFlow.js for face recognition
- **Hardware**: Integration with AR glasses SDK
```

### Example Implementation Phase

```markdown
## Phase 1: Core Setup (Day 1)
1. Initialize React Native project
2. Set up Express.js backend
3. Configure SQLite database
4. Create basic face detection pipeline
5. Implement voice command recognition
6. Build simple contact management interface
```

## Expected Outcomes 📋

By the end of this step, you should have:

- [ ] Complete app specification document (app-specification.md)
- [ ] Detailed implementation plan (implementation-plan.md)
- [ ] Mentor validation of your approach
- [ ] Clear understanding of what you'll build
- [ ] Confidence in your technical decisions
- [ ] Ready-to-execute development plan

## Next Steps 🔄

In the next workshop step, you'll:

1. Hand off your specification and plan to GitHub Copilot Agent Mode
2. Watch as Copilot builds your application following your documentation
3. Make real-time adjustments and refinements
4. Deploy your working application

## Troubleshooting 🔧

### Prompt Files Not Working

- Ensure you're using the latest VS Code and Copilot extensions
- Try typing the command in a fresh chat session
- Check that you're properly authenticated with GitHub

### Generic or Incomplete Outputs

- Provide more specific context about your app
- Ask targeted follow-up questions
- Reference your previous work from Step 2

### Technical Concerns

- Always validate complex technical decisions with the mentor
- Ask for simpler alternatives if something seems too complex
- Consider the workshop time constraints in your planning

---

**Ready to build?** Once you've completed your specification and implementation plan, proceed to [Workshop Step 4: Build Your Application](workshop-step-4-build-your-application.md) to see your app come to life! 🚀
