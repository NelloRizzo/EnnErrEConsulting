// AdminHomePage.tsx
import React, { useState } from 'react';
import './Dashboard.scss';

interface Course {
    id: number;
    title: string;
    participants: number;
    status: 'active' | 'draft' | 'completed';
}

const AdminHomePage: React.FC = () => {
    const [courses, setCourses] = useState<Course[]>([
        { id: 1, title: 'React Avanzato', participants: 24, status: 'active' },
        { id: 2, title: 'TypeScript per Sviluppatori', participants: 18, status: 'active' },
        { id: 3, title: 'Gestione Progetti Agile', participants: 0, status: 'draft' },
        { id: 4, title: 'Digital Marketing Fundamentals', participants: 32, status: 'completed' },
    ]);

    return (
        <div className="dashboard-content">
            <h2>Dashboard Amministrativa</h2>

            <div className="stats-grid">
                <div className="stat-card">
                    <h3>Corsi Totali</h3>
                    <p className="stat-number">12</p>
                </div>
                <div className="stat-card">
                    <h3>Iscrizioni Attive</h3>
                    <p className="stat-number">74</p>
                </div>
                <div className="stat-card">
                    <h3>Utenti Registrati</h3>
                    <p className="stat-number">158</p>
                </div>
                <div className="stat-card">
                    <h3>Fatturato Mensile</h3>
                    <p className="stat-number">€12.450</p>
                </div>
            </div>

            <div className="recent-courses">
                <h3>Corsi Recenti</h3>
                <table>
                    <thead>
                        <tr>
                            <th>Nome Corso</th>
                            <th>Partecipanti</th>
                            <th>Stato</th>
                            <th>Azioni</th>
                        </tr>
                    </thead>
                    <tbody>
                        {courses.map(course => (
                            <tr key={course.id}>
                                <td>{course.title}</td>
                                <td>{course.participants}</td>
                                <td>
                                    <span className={`status-badge status-${course.status}`}>
                                        {course.status === 'active' ? 'Attivo' :
                                            course.status === 'draft' ? 'Bozza' : 'Completato'}
                                    </span>
                                </td>
                                <td>
                                    <button className="action-btn edit">Modifica</button>
                                    <button className="action-btn delete">Elimina</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default AdminHomePage;