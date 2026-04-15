import { useState } from "react";
import API from "../../api/api";

export default function CategoryForm({ onSuccess }) {
  const [name, setName] = useState("");

  const handleSubmit = () => {
    API.post("/categories", { name })
      .then(() => {
        alert("Category added!");
        setName("");
        onSuccess();
      });
  };

  return (
    <div className="mb-4 bg-white p-4 rounded shadow">
      <h2 className="font-bold mb-2">Add Category</h2>

      <input
        className="border p-2 mr-2"
        placeholder="Category Name"
        value={name}
        onChange={e => setName(e.target.value)}
      />

      <button
        onClick={handleSubmit}
        className="bg-blue-500 text-white px-3 py-1 rounded"
      >
        Add
      </button>
    </div>
  );
}