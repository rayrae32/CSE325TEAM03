# Contributing to Team 3 CSE 325 Project

Thank you for contributing to our team project! This document outlines the process and guidelines for contributing to our .NET Blazor application.

## 🤝 Team Collaboration Principles

- **Communication:** Keep team members informed of your progress and any blockers
- **Respect:** Value everyone's ideas and contributions
- **Quality:** Write clean, well-documented, and tested code
- **Timeliness:** Meet deadlines and attend team meetings
- **Support:** Help teammates when they encounter challenges

## 🔄 Git Workflow

### Branch Naming Convention

- `feature/[feature-name]` - New features (e.g., `feature/user-authentication`)
- `bugfix/[issue-description]` - Bug fixes (e.g., `bugfix/login-validation`)
- `hotfix/[critical-issue]` - Critical production fixes
- `docs/[documentation-update]` - Documentation changes

### Workflow Steps

1. **Pull Latest Changes**

   ```bash
   git checkout develop
   git pull origin develop
   ```

2. **Create Feature Branch**

   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make Your Changes**

   - Write clear, descriptive code
   - Follow C# and .NET coding standards
   - Add comments for complex logic
   - Update documentation as needed

4. **Commit Your Changes**

   ```bash
   git add .
   git commit -m "feat: Add user authentication feature"
   ```

5. **Push to Remote**

   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create Pull Request**

   - Go to GitHub repository
   - Create Pull Request from your branch to `develop`
   - Add descriptive title and description
   - Request review from at least one team member

7. **Code Review**
   - Address any feedback or requested changes
   - Once approved, the PR can be merged

## 📝 Commit Message Guidelines

Follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

- `feat:` - New feature
- `fix:` - Bug fix
- `docs:` - Documentation changes
- `style:` - Code style changes (formatting, missing semicolons, etc.)
- `refactor:` - Code refactoring
- `test:` - Adding or updating tests
- `chore:` - Maintenance tasks

**Examples:**

```
feat: Add shopping cart functionality
fix: Resolve null reference in user service
docs: Update API documentation for payment endpoint
refactor: Simplify authentication logic
test: Add unit tests for order processing
```

## 💻 Code Standards

### C# Coding Conventions

- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use PascalCase for class names and method names
- Use camelCase for local variables and parameters
- Use meaningful, descriptive names
- Keep methods focused and small (single responsibility)

### Code Formatting

- Indentation: 4 spaces (no tabs)
- Maximum line length: 120 characters
- Use auto-formatting tools in Visual Studio/VS Code

### Comments and Documentation

- Add XML documentation comments for public methods and classes
- Explain "why" not "what" in comments
- Keep comments up-to-date with code changes

**Example:**

```csharp
/// <summary>
/// Authenticates a user with the provided credentials.
/// </summary>
/// <param name="username">The username to authenticate</param>
/// <param name="password">The password to verify</param>
/// <returns>AuthResult containing the authentication token if successful</returns>
public async Task<AuthResult> AuthenticateAsync(string username, string password)
{
    // Implementation
}
```

## 🧪 Testing Requirements

- Write unit tests for business logic
- Ensure existing tests pass before submitting PR
- Aim for meaningful test coverage (not just percentages)
- Test edge cases and error conditions

## 🔍 Code Review Process

### As a Reviewer

- Review code within 24 hours of PR creation
- Provide constructive feedback
- Check for:
  - Code quality and readability
  - Adherence to project standards
  - Potential bugs or edge cases
  - Performance implications
  - Security concerns

### As a Contributor

- Respond to feedback promptly
- Be open to suggestions and improvements
- Explain your decisions when requested
- Don't take feedback personally

## ⚠️ Important Notes

- **Never commit sensitive data** (passwords, API keys, connection strings)
- **Test locally** before pushing
- **Keep commits atomic** (one logical change per commit)
- **Pull before you push** to avoid merge conflicts
- **Communicate blockers** early

## 📋 Pull Request Template

When creating a PR, include:

```markdown
## Description

[Brief description of changes]

## Type of Change

- [ ] New feature
- [ ] Bug fix
- [ ] Documentation update
- [ ] Refactoring
- [ ] Other (describe)

## Testing

- [ ] Unit tests added/updated
- [ ] Manual testing completed
- [ ] All existing tests pass

## Checklist

- [ ] Code follows project style guidelines
- [ ] Self-review completed
- [ ] Comments added for complex logic
- [ ] Documentation updated
- [ ] No merge conflicts

## Related Issues

Closes #[issue-number]
```

## 🆘 Getting Help

If you need assistance:

1. Check project documentation
2. Ask in team communication channel
3. Reach out to the current week's team leader
4. Consult with teammates during meetings

## 📚 Resources

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Blazor Documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Git Best Practices](https://www.git-scm.com/book/en/v2)

---

Thank you for being a valuable member of Team 3! 🚀
