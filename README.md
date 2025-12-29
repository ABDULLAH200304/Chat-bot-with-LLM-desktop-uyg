تمام 👍
هذا **README.md باللغة الإنكليزية** وجاهز للاستخدام في GitHub أو تسليم مشروع جامعي:

---

# ChatBotApp — Desktop Chat Bot with LLM (WPF)

**ChatBotApp** is a Windows desktop application built with **C# and WPF** that allows users to chat with a **Large Language Model (LLM)** using the OpenAI API.
The application provides a clean and simple chat interface where users can enter their API key, send messages, and receive intelligent AI-generated responses.

---

## Features

* 🖥️ Desktop application built with **WPF**
* 💬 Real-time chat interface (User / Assistant)
* 🧠 Context-aware responses using chat history
* 🔐 API Key input directly inside the application
* 📜 Message timestamps and role-based message alignment
* ⚡ Asynchronous API communication

---

## Technologies Used

* **C#**
* **WPF (.NET)**
* **OpenAI API**
* **MVVM-friendly structure**
* **ObservableCollection** for real-time UI updates

---

## Requirements

* Windows 10 / 11
* Visual Studio 2022 or later
* .NET (according to project configuration)
* Valid OpenAI API Key

---

## How to Run

1. Clone or download the project.
2. Open the solution in **Visual Studio**.
3. Restore NuGet packages.
4. Run the application (**F5**).
5. Inside the app:

   * Enter your **OpenAI API Key**
   * Click **Set Key**
   * Type a message and press **Send** or **Enter**

---

## How It Works

* User messages are stored in an in-memory chat history.
* The entire conversation context is sent to the LLM to generate accurate replies.
* Responses are returned asynchronously and displayed in the UI.
* Messages are visually aligned based on role (User / Assistant).

---

## Project Structure

```
ChatBotApp/
│
├── App.xaml
├── App.xaml.cs
├── AssemblyInfo.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
│
├── ChatMessage.cs
├── OpenAiService.cs
└── ChatBotApp.csproj
```

### File Descriptions

* **MainWindow.xaml / .cs**
  Handles UI layout, user interactions, and message rendering.

* **OpenAiService.cs**
  Manages communication with the OpenAI API and returns AI responses.

* **ChatMessage.cs**
  Data model representing chat messages (role, text, timestamp).

* **App.xaml**
  Application startup and WPF configuration.

---

## Model Configuration

The default model used in the project:

```
gpt-4o-mini
```

You can change the model in `OpenAiService.cs` by updating the `ChatClient` initialization.

---

## Security Notes

* API keys are entered manually and kept **only in memory** during runtime.
* The project does not store API keys permanently.
* Do not share your API key publicly.

---

## Future Improvements

* Clear chat button
* Save chat history to file (TXT / JSON)
* Streaming responses
* Theme switching (Dark / Light)
* Secure API key storage (Windows Credential Manager)
* Multi-model support

---

## Educational Purpose

This project is suitable for:

* University assignments
* Learning WPF
* Understanding LLM integration
* Desktop AI application development

---

## Author

**Abdullah Ali**
Software Engineering Student

---

إذا أردت:

* نسخة **أكاديمية مختصرة** للتسليم الجامعي
* أو **README احترافي مع Badges وScreenshots**
* أو **شرح شفهي للمشروع** كأنك تقدمه للدكتور

قل لي ماذا تريد بالضبط وسأجهزه لك فورًا ✅
