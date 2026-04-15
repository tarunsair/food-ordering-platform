import { useState } from "react";
import CategoryForm from "./CategoryForm";
import MenuForm from "./MenuForm";
import MenuTable from "./MenuTable";

export default function AdminDashboard() {
  const [refresh, setRefresh] = useState(false);

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Admin Panel</h1>

      <CategoryForm onSuccess={() => setRefresh(!refresh)} />
      <MenuForm onSuccess={() => setRefresh(!refresh)} />

      <MenuTable refresh={refresh} />
    </div>
  );
}