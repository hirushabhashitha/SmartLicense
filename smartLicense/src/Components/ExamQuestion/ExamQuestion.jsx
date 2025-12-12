import "../styles/exam.css";

export default function ExamQuestion({ qIndex, question, answer, onChange }) {
  const options = JSON.parse(question.options);

  return (
    <div className="exam-question">
      <h3>ප්‍රශ්නය {qIndex + 1}</h3>
      <p className="q-text">{question.qText}</p>

      <div className="options">
        {options.map((opt, i) => (
          <label key={i} className="option-item">
            <input
              type="radio"
              name={`q_${question.id}`}
              value={opt}
              checked={answer === opt}
              onChange={() => onChange(question.id, opt)}
            />
            {String.fromCharCode(65 + i)}. {opt}
          </label>
        ))}
      </div>
    </div>
  );
}
