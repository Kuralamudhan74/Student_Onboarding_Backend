<div align="center">

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                         COVER PAGE                                -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<img src="https://img.shields.io/badge/CONFIDENTIAL-Business_Document-dc2626?style=for-the-badge" />

<br/><br/>

# 📋 BUSINESS REQUIREMENTS DOCUMENT

<br/>

```
╔══════════════════════════════════════════════════════════════╗
║                                                              ║
║                      B O O K Q W I K                         ║
║                                                              ║
║         Peer-to-Peer Short-Term Space Rental Platform        ║
║                                                              ║
╚══════════════════════════════════════════════════════════════╝
```

<br/>

| | |
|---|---|
| **Document Version** | `v2.0` |
| **Date** | April 2, 2026 |
| **Status** | 🟡 Draft for Stakeholder Review |
| **Classification** | Confidential |
| **Prepared By** | Product & Business Analysis Team |
| **Approved By** | _Pending Sign-off_ |

<br/>

---

<img src="https://img.shields.io/badge/Platform-Web_+_Mobile-5B5BD6?style=flat-square" /> <img src="https://img.shields.io/badge/Model-Commission_Marketplace-22C55E?style=flat-square" /> <img src="https://img.shields.io/badge/Phase-MVP-F59E0B?style=flat-square" />

</div>

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                      TABLE OF CONTENTS                            -->
<!-- ══════════════════════════════════════════════════════════════════ -->

## 📑 Table of Contents

> _Click any section to navigate directly_

| # | Section | Description |
|:-:|---------|-------------|
| 1 | [Executive Summary](#-1-executive-summary) | Platform vision, market context, differentiators |
| 2 | [Business Objectives](#-2-business-objectives) | Measurable goals & Year 1 KPIs |
| 3 | [Scope Definition](#-3-scope-definition) | In-scope MVP vs. future phases |
| 4 | [Stakeholders](#-4-stakeholders) | Roles & responsibilities matrix |
| 5 | [User Personas](#-5-user-personas) | Detailed persona profiles |
| 6 | [User Journey Flows](#-6-user-journey-flows) | End-to-end flows with diagrams |
| 7 | [Functional Requirements](#-7-functional-requirements) | Module-wise detailed requirements |
| 8 | [Non-Functional Requirements](#-8-non-functional-requirements) | Performance, security, scalability |
| 9 | [System Architecture & Modules](#-9-system-architecture--modules) | Architecture, modules, data model |
| 10 | [Data Flow Diagrams](#-10-data-flow-diagrams) | Booking, payment & moderation flows |
| 11 | [Assumptions & Constraints](#-11-assumptions--constraints) | Operating boundaries |
| 12 | [Risk Register](#-12-risk-register) | Risks, probability, impact, mitigations |
| 13 | [Revenue Model](#-13-revenue-model) | Commission logic, projections, future streams |
| 14 | [Future Enhancements](#-14-future-enhancements) | Phase 2 & Phase 3 roadmap |

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                    SECTION 1: EXECUTIVE SUMMARY                   -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 📌 1. Executive Summary

</div>

---

> **BookQwik** is a peer-to-peer marketplace platform (web + mobile) that enables individuals and businesses to list their underutilized spaces for short-term rental. Renters discover, book, and pay for spaces on an **hourly or daily basis** for activities such as meetings, tuition classes, workshops, small gatherings, and events.

### 🎯 The Problem

```
╔══════════════════════════════════════════════════════════════════════════╗
║                                                                          ║
║   🏠 SUPPLY SIDE                          🔍 DEMAND SIDE                ║
║   ─────────────                           ────────────                   ║
║   Millions of spaces sit idle:            Users struggle to find:        ║
║                                                                          ║
║   • Spare rooms in homes                  • Affordable meeting rooms     ║
║   • Classrooms after hours                • Flexible tuition spaces      ║
║   • Empty halls on weekdays               • Short-term workshop venues   ║
║   • Terraces & open spaces                • Event spaces without         ║
║   • Conference rooms in offices             long-term commitment         ║
║                                                                          ║
║   ❌ No easy way to monetize              ❌ Expensive hotel rentals     ║
║   ❌ Safety concerns with strangers       ❌ Noisy cafes are not ideal   ║
║   ❌ No platform for hourly rental        ❌ Long-term leases required   ║
║                                                                          ║
╠══════════════════════════════════════════════════════════════════════════╣
║                                                                          ║
║              ✅ BookQwik bridges this gap with a trusted,                ║
║                 commission-based marketplace model                       ║
║                                                                          ║
╚══════════════════════════════════════════════════════════════════════════╝
```

### 🏆 Key Differentiators

| # | Differentiator | How BookQwik Stands Out |
|:-:|----------------|------------------------|
| 1 | **Hyper-local, activity-based** | Focus on short-term usage (not overnight stays like Airbnb) |
| 2 | **Hourly + Daily pricing** | Flexible billing for tutors, freelancers, and event organizers |
| 3 | **Mandatory amenity checklist** | Consistent quality with required WiFi, furniture, and event-fit data |
| 4 | **Accept / Reject / Counter-offer** | Owners control who uses their space with a negotiation flow |
| 5 | **Lightweight listing** | Designed for non-commercial owners (homemakers, small businesses) |

### 🔍 Comparable Platforms

```
┌─────────────────┬─────────────────┬─────────────────┬─────────────────┐
│    🏠 Airbnb     │  🏢 Peerspace    │   🚪 NoBroker    │  💼 Breather     │
│                 │                 │                 │                 │
│  Accommodation  │  Event venues   │  Rental without │  On-demand      │
│  rentals        │  (US-focused)   │  brokers        │  workspaces     │
│                 │                 │  (India)        │                 │
│  ⚠️ Not hourly   │  ⚠️ High-end     │  ⚠️ Long-term    │  ⚠️ Corporate     │
│    focused      │    only         │    leases       │    only         │
├─────────────────┴─────────────────┴─────────────────┴─────────────────┤
│                                                                       │
│   ✅ BookQwik = Hourly/Daily + All space types + India-first +       │
│                 Individual owners + Activity-based search              │
│                                                                       │
└───────────────────────────────────────────────────────────────────────┘
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                SECTION 2: BUSINESS OBJECTIVES                     -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 🎯 2. Business Objectives

</div>

---

| # | Objective | 📊 Success Metric | 🎯 Year 1 Target | Status |
|:-:|-----------|:------------------:|:-----------------:|:------:|
| BO-1 | Build strong supply-side marketplace | Active verified listings | **5,000+** listings in 3 metro cities | 🔴 Not Started |
| BO-2 | Drive demand-side adoption | Monthly active renters | **10,000+** renters with 1+ booking | 🔴 Not Started |
| BO-3 | Generate sustainable commission revenue | Gross Transaction Value | **INR 5 Cr** GTV @ 12-15% commission | 🔴 Not Started |
| BO-4 | Maintain high trust & safety | Avg rating + dispute rate | Rating ≥ **4.2**/5, disputes < **2%** | 🔴 Not Started |
| BO-5 | Achieve product-market fit | Repeat booking rate | **30%+** rebook within 60 days | 🔴 Not Started |
| BO-6 | Ensure platform reliability | Uptime SLA | **99.5%** uptime | 🔴 Not Started |

### 📈 Objective Hierarchy

```
                    ┌──────────────────────────┐
                    │   🌟 COMPANY VISION       │
                    │  "Make every idle space   │
                    │   earn for its owner"     │
                    └────────────┬─────────────┘
                                 │
              ┌──────────────────┼──────────────────┐
              │                  │                   │
              ▼                  ▼                   ▼
   ┌──────────────────┐ ┌──────────────┐ ┌──────────────────┐
   │ 📦 SUPPLY         │ │ 👥 DEMAND    │ │ 💰 REVENUE       │
   │                   │ │              │ │                  │
   │ 5,000 listings    │ │ 10,000 MAR   │ │ INR 5 Cr GTV    │
   │ 3 cities          │ │ 30% repeat   │ │ 12-15% take rate │
   └──────────┬───────┘ └──────┬───────┘ └────────┬─────────┘
              │                │                   │
              ▼                ▼                   ▼
   ┌──────────────────┐ ┌──────────────┐ ┌──────────────────┐
   │ 🛡️ TRUST          │ │ ⚡ QUALITY   │ │ 🔧 RELIABILITY   │
   │                   │ │              │ │                  │
   │ Avg ≥ 4.2★        │ │ Disputes     │ │ 99.5% uptime     │
   │ KYC verified      │ │ < 2%         │ │ < 2s load time   │
   └──────────────────┘ └──────────────┘ └──────────────────┘
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                  SECTION 3: SCOPE DEFINITION                      -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 📐 3. Scope Definition

</div>

---

### ✅ 3.1 In Scope (MVP)

| Module | Included Features | Priority |
|:-------|:-----------------|:--------:|
| 👤 **User Management** | Registration, login, profiles, role-based access (Owner, Renter, Admin) | 🔴 P0 |
| 🏠 **Space Listing** | Create/edit/delete, image/video upload, amenities, pricing, availability calendar | 🔴 P0 |
| 🔍 **Search & Discovery** | Location-based search, filters (price, amenities, event type), map view | 🔴 P0 |
| 📅 **Booking** | Request flow, accept/reject/counter-offer, time slots, booking history | 🔴 P0 |
| 💳 **Payments** | Gateway integration, hourly/daily billing, commission deduction, owner payouts | 🔴 P0 |
| 🔔 **Notifications** | In-app + push + email for booking lifecycle events | 🔴 P0 |
| ⭐ **Ratings & Reviews** | Post-booking mutual ratings, public reviews | 🟡 P1 |
| 🛠️ **Admin Panel** | User mgmt, listing moderation, transactions, commission config, disputes | 🔴 P0 |
| 📱 **Mobile App** | Android & iOS (renter-focused), responsive web for all roles | 🔴 P0 |

### ❌ 3.2 Out of Scope (MVP)

| Feature | Phase | Reason |
|:--------|:-----:|:-------|
| AI-based space recommendations | Phase 2 | Requires usage data to train models |
| Dynamic/surge pricing | Phase 2 | Needs demand pattern analysis |
| In-app chat/messaging | Phase 2 | Notifications + phone sufficient for MVP |
| Multi-language support | Phase 2 | English-only initially |
| Insurance/damage protection | Phase 3 | Requires insurance partner integration |
| Subscription plans for owners | Phase 3 | Freemium model sufficient for MVP |
| Third-party API integrations | Phase 3 | Focus on core platform first |
| Overnight/accommodation bookings | ❌ | Out of core value proposition |

### 🗺️ 3.3 Phase Roadmap

```
══════════════════════════════════════════════════════════════════════════════

  MONTH    1    2    3    4    5    6    7    8    9    10   11   12
         ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤

  ████████████████████████████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
  ▲ PHASE 1 — MVP (Month 1-5)
  │ • Core platform (listing, search, booking, payments)
  │ • Admin panel
  │ • Mobile apps
  │ • Launch in 2 cities
  │
  ░░░░░░░░░░░░░░░░░░░░░░░░████████████████████████░░░░░░░░░░░░░░░░░░░
                           ▲ PHASE 2 — Growth (Month 6-9)
                           │ • AI recommendations
                           │ • In-app messaging
                           │ • Dynamic pricing
                           │ • Instant Book
                           │ • Multi-language
                           │
  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████████████████░░
                                                     ▲ PHASE 3 — Scale (Month 10-12)
                                                     │ • Insurance integration
                                                     │ • Recurring bookings
                                                     │ • Enterprise dashboard
                                                     │ • Tier-2 city expansion

══════════════════════════════════════════════════════════════════════════════
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                    SECTION 4: STAKEHOLDERS                        -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 👥 4. Stakeholders

</div>

---

```
                          ┌──────────────────────┐
                          │    🌟 FOUNDER / CEO    │
                          │   Product Sponsor     │
                          │   Vision & Approvals  │
                          └──────────┬───────────┘
                                     │
                 ┌───────────────────┼───────────────────┐
                 │                   │                    │
                 ▼                   ▼                    ▼
    ┌────────────────────┐ ┌────────────────┐ ┌──────────────────┐
    │ 📋 PRODUCT MANAGER  │ │ 🔧 ENGINEERING │ │ 🎨 UX / DESIGN   │
    │                    │ │    LEAD        │ │                  │
    │ Requirements owner │ │ Architecture   │ │ Wireframes       │
    │ Roadmap & priority │ │ Tech decisions │ │ Design system    │
    │ Stakeholder align  │ │ Sprint planning│ │ Prototypes       │
    └────────┬───────────┘ └───────┬────────┘ └────────┬─────────┘
             │                     │                    │
             ▼                     ▼                    │
    ┌────────────────────┐ ┌────────────────┐          │
    │ 📊 BUSINESS ANALYST │ │ 👨‍💻 DEVELOPERS  │          │
    │                    │ │ (FE + BE + QA) │          │
    │ This document      │ │                │          │
    │ User stories       │ │ Implementation │          │
    │ Acceptance criteria│ │ Testing        │          │
    └────────────────────┘ └────────────────┘          │
                                                       │
         ┌───────────────────┬─────────────────────────┘
         │                   │
         ▼                   ▼
┌────────────────┐  ┌───────────────────┐  ┌────────────────────┐
│ 📢 MARKETING    │  │ ⚖️ LEGAL/COMPLIANCE │  │ 💰 FINANCE         │
│                │  │                   │  │                    │
│ User acq.      │  │ Privacy policy    │  │ Payment reconcile  │
│ Campaigns      │  │ Terms of service  │  │ Commission track   │
│ Content        │  │ Rental regulations│  │ Payout management  │
└────────────────┘  └───────────────────┘  └────────────────────┘
```

### 📋 RACI Matrix

| Activity | Founder | PM | BA | Eng Lead | Dev Team | UX | Marketing | Legal | Finance |
|:---------|:-------:|:--:|:--:|:--------:|:--------:|:--:|:---------:|:-----:|:-------:|
| Requirements approval | **A** | **R** | **C** | C | I | C | I | I | I |
| Architecture decisions | I | C | I | **A/R** | **C** | I | — | — | — |
| UI/UX design | I | **A** | C | C | I | **R** | I | — | — |
| Feature development | I | **A** | C | **R** | **R** | C | — | — | — |
| Go-to-market strategy | **A** | C | I | I | — | I | **R** | C | C |
| Legal compliance | **A** | I | I | C | — | — | I | **R** | C |
| Payment operations | I | C | I | C | **R** | — | — | C | **A/R** |

> **R** = Responsible | **A** = Accountable | **C** = Consulted | **I** = Informed

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                    SECTION 5: USER PERSONAS                       -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 🧑‍🤝‍🧑 5. User Personas

</div>

---

### 👩‍🏠 Persona 1: Priya — The Homeowner

```
╔══════════════════════════════════════════════════════════════════════╗
║  👩‍🏠 PRIYA SHARMA  |  Age: 35  |  Bangalore  |  Homemaker          ║
╠══════════════════════════════════════════════════════════════════════╣
║                                                                      ║
║  🏠 SPACE: Spare hall + terrace at home                              ║
║  💻 TECH: Moderate (WhatsApp, Instagram, Swiggy)                     ║
║                                                                      ║
║  ✅ MOTIVATIONS                    ❌ PAIN POINTS                    ║
║  ──────────────                    ─────────────                     ║
║  • Earn passive income from        • Doesn't know how to find       ║
║    underutilized space               renters safely                  ║
║  • Maintain control over who       • Worried about property damage   ║
║    uses her property               • Doesn't want long-term tenants  ║
║  • Earn INR 15K-25K/month         • No platform for hourly rentals  ║
║                                                                      ║
║  🎯 GOALS                          🔑 KEY NEEDS                     ║
║  ────────                          ──────────                        ║
║  • List hall for tuition &         • Easy listing process            ║
║    small meetings                  • Approve/reject bookings         ║
║  • Flexible schedule               • Secure, verified payments      ║
║  • Safe, verified renters          • Calendar availability control   ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
```

### 🏢 Persona 2: Raj — The Commercial Operator

```
╔══════════════════════════════════════════════════════════════════════╗
║  🏢 RAJ MEHTA  |  Age: 42  |  Hyderabad  |  Training Institute     ║
╠══════════════════════════════════════════════════════════════════════╣
║                                                                      ║
║  🏠 SPACE: 3 classrooms (idle 40% of the time)                      ║
║  💻 TECH: High                                                       ║
║                                                                      ║
║  ✅ MOTIVATIONS                    ❌ PAIN POINTS                    ║
║  ──────────────                    ─────────────                     ║
║  • Monetize idle classroom         • Classrooms sit empty on        ║
║    hours (evenings, weekends)        evenings & weekends             ║
║  • Maximize revenue per            • Social media ads are           ║
║    square foot                       inconsistent                    ║
║                                                                      ║
║  🎯 GOALS                          🔑 KEY NEEDS                     ║
║  ────────                          ──────────                        ║
║  • Fill idle slots with workshop   • Multi-listing management       ║
║    organizers and tutors           • Hourly pricing configuration   ║
║  • Manage multiple listings        • Bulk availability settings     ║
║    efficiently                     • Detailed payout reports        ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
```

### 📚 Persona 3: Ankit — The Freelance Tutor

```
╔══════════════════════════════════════════════════════════════════════╗
║  📚 ANKIT JOSHI  |  Age: 28  |  Pune  |  Freelance Math Tutor      ║
╠══════════════════════════════════════════════════════════════════════╣
║                                                                      ║
║  🔍 LOOKING FOR: Quiet room with whiteboard for 3-4 students        ║
║  💻 TECH: High (digital native)                                      ║
║                                                                      ║
║  ✅ MOTIVATIONS                    ❌ PAIN POINTS                    ║
║  ──────────────                    ─────────────                     ║
║  • Affordable space near           • Can't afford permanent         ║
║    students' locations               classroom                      ║
║  • Professional environment        • Cafes are too noisy            ║
║    for teaching                    • Flats require long-term        ║
║                                      commitment                     ║
║                                                                      ║
║  🎯 GOALS                          🔑 KEY NEEDS                     ║
║  ────────                          ──────────                        ║
║  • Book 2-3 hours daily            • Location-based search          ║
║  • Keep costs under INR 300/hr    • Amenity filters (whiteboard)   ║
║  • Consistent, reliable spaces    • Flexible hourly booking        ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
```

### 🎪 Persona 4: Meera — The Event Organizer

```
╔══════════════════════════════════════════════════════════════════════╗
║  🎪 MEERA KAPOOR  |  Age: 30  |  Mumbai  |  Event Planner          ║
╠══════════════════════════════════════════════════════════════════════╣
║                                                                      ║
║  🔍 LOOKING FOR: Unique venues for workshops & team events          ║
║  💻 TECH: High                                                       ║
║                                                                      ║
║  ✅ MOTIVATIONS                    ❌ PAIN POINTS                    ║
║  ──────────────                    ─────────────                     ║
║  • Find unique, affordable         • Hotels are too expensive       ║
║    venues for corporate events     • Community halls need weeks     ║
║  • Quick booking without             of advance booking             ║
║    long negotiations               • Quality varies wildly          ║
║                                                                      ║
║  🎯 GOALS                          🔑 KEY NEEDS                     ║
║  ────────                          ──────────                        ║
║  • Find spaces for 30+ people      • Event-type filtering          ║
║  • Compare options quickly         • Detailed photos/videos        ║
║  • Book for full days              • Capacity info & reviews       ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
```

### 🛡️ Persona 5: Vikram — The Platform Admin

```
╔══════════════════════════════════════════════════════════════════════╗
║  🛡️ VIKRAM REDDY  |  Age: 32  |  Operations Manager @ BookQwik    ║
╠══════════════════════════════════════════════════════════════════════╣
║                                                                      ║
║  💻 TECH: Very High                                                  ║
║                                                                      ║
║  🎯 GOALS                          🔑 KEY NEEDS                     ║
║  ────────                          ──────────                        ║
║  • Ensure platform quality          • Dashboard with live KPIs      ║
║  • Approve/reject listings          • Listing moderation queue      ║
║    quickly                         • Transaction logs & exports    ║
║  • Resolve disputes fairly         • User management tools         ║
║  • Monitor revenue growth          • Commission configuration      ║
║  • Configure commission rates      • Dispute resolution workflow   ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                 SECTION 6: USER JOURNEY FLOWS                     -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 🔄 6. User Journey Flows

</div>

---

### 🏠 6.1 Space Owner Journey

```
    ┌─────────┐
    │  START  │
    └────┬────┘
         │
         ▼
┌─────────────────┐
│ 📝 REGISTER /   │──── Email + OTP / Google OAuth
│    LOGIN        │
└────────┬────────┘
         │
         ▼
┌─────────────────┐     ┌──────────────────────────────────────────────┐
│ 🏠 CREATE       │     │  📋 LISTING FORM STEPS:                      │
│    LISTING      │────▶│                                              │
│                 │     │  Step 1 ──▶ Basic Info (title, type, desc)  │
└────────┬────────┘     │  Step 2 ──▶ Amenities (mandatory+optional) │
         │              │  Step 3 ──▶ Pricing (hourly / daily)       │
         │              │  Step 4 ──▶ Availability (calendar)        │
         │              │  Step 5 ──▶ Photos / Videos (min 3)        │
         │              │  Step 6 ──▶ House Rules & Capacity         │
         │              │  Step 7 ──▶ Submit for Review ✅            │
         │              └──────────────────────────────────────────────┘
         ▼
┌─────────────────┐
│ 🔍 ADMIN        │
│    MODERATION   │◀──── Within 24-48 hours
│                 │
└────────┬────────┘
         │
         ├──────────────────────────────────┐
         │                                  │
         ▼                                  ▼
┌─────────────────┐              ┌─────────────────┐
│ ✅ APPROVED      │              │ ❌ REJECTED      │
│                 │              │                 │
│ Listing LIVE    │              │ Notified with   │
│ Added to search │              │ reason; can     │
│ index           │              │ edit & resubmit │
└────────┬────────┘              └─────────────────┘
         │
         ▼
┌─────────────────┐
│ 🔔 RECEIVE      │◀──── Push + Email notification
│    BOOKING      │
│    REQUEST      │
└────────┬────────┘
         │
         ├─────────────────┬──────────────────┐
         │                 │                  │
         ▼                 ▼                  ▼
┌──────────────┐  ┌──────────────┐  ┌──────────────────┐
│ ✅ ACCEPT     │  │ ❌ REJECT     │  │ 🔄 COUNTER-OFFER │
│              │  │              │  │                  │
│ Payment      │  │ Renter       │  │ Suggest new      │
│ captured     │  │ notified     │  │ time / price     │
│ Booking      │  │ No charge    │  │ Renter decides   │
│ confirmed    │  │              │  │                  │
└──────┬───────┘  └──────────────┘  └──────────────────┘
       │
       ▼
┌─────────────────┐
│ 📅 BOOKING DAY  │──── Renter arrives & uses space
│                 │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ 🎯 POST-BOOKING │
│                 │
│ • Rate renter ⭐│
│ • Receive payout│
│   (after comm.) │
│ • View earnings │
│   dashboard     │
└─────────────────┘
```

### 🔍 6.2 Space Renter Journey

```
    ┌─────────┐
    │  START  │
    └────┬────┘
         │
         ▼
┌─────────────────┐
│ 📝 REGISTER /   │──── Email + OTP / Google OAuth
│    LOGIN        │
└────────┬────────┘
         │
         ▼
┌─────────────────┐     ┌───────────────────────────────────────────┐
│ 🔍 SEARCH &     │     │  🎛️ FILTER OPTIONS:                       │
│    DISCOVER     │────▶│                                           │
│                 │     │  📍 Location (GPS / manual)               │
│  • Enter area   │     │  💰 Price range (slider)                  │
│  • Use GPS      │     │  🏠 Space type                            │
│  • Browse map   │     │  🎯 Event type                            │
│                 │     │  🪑 Amenities (multi-select)              │
└────────┬────────┘     │  📅 Date & time availability              │
         │              │  👥 Capacity (min guests)                 │
         │              │  ⭐ Rating (min stars)                    │
         │              │  🔀 Sort: Price / Rating / Distance       │
         │              └───────────────────────────────────────────┘
         ▼
┌─────────────────┐
│ 📄 VIEW LISTING │
│    DETAIL       │
│                 │
│ • Photo gallery │
│ • All amenities │
│ • Pricing table │
│ • Availability  │
│ • House rules   │
│ • Owner profile │
│ • Reviews ⭐    │
└────────┬────────┘
         │
         ▼
┌─────────────────┐     ┌───────────────────────────────────────────┐
│ 📅 SELECT TIME  │     │  💰 PRICING BREAKDOWN:                    │
│    SLOT &       │────▶│                                           │
│    REQUEST      │     │  Base price     = Hours × Rate            │
│    BOOKING      │     │  Service fee    = 10% of base             │
│                 │     │  GST            = 18% on service fee      │
│ • Choose date   │     │  ─────────────────────────────            │
│ • Pick hours    │     │  Total payable  = Base + Fee + GST        │
│ • Guest count   │     │                                           │
│ • Add note      │     └───────────────────────────────────────────┘
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ ⏳ WAIT FOR     │◀──── Timeout: 24 hours (auto-cancel)
│    OWNER        │
│    RESPONSE     │
└────────┬────────┘
         │
         ├─────────────────┬──────────────────┐
         │                 │                  │
         ▼                 ▼                  ▼
┌──────────────┐  ┌──────────────┐  ┌──────────────────┐
│ ✅ ACCEPTED   │  │ ❌ REJECTED   │  │ 🔄 COUNTER-OFFER │
│              │  │              │  │                  │
│ Payment      │  │ Full refund  │  │ Review new terms │
│ captured     │  │ Alternatives │  │ Accept / Decline │
│              │  │ suggested    │  │ (12 hr expiry)   │
└──────┬───────┘  └──────────────┘  └──────────────────┘
       │
       ▼
┌─────────────────┐     ┌───────────────────────────────────────────┐
│ ✅ BOOKING      │     │  📩 CONFIRMATION INCLUDES:                │
│    CONFIRMED    │────▶│                                           │
│                 │     │  ✅ Exact address revealed                │
│                 │     │  📍 Map directions                        │
│                 │     │  📋 Check-in instructions                 │
│                 │     │  🔔 Reminders: 24hr + 1hr before         │
└────────┬────────┘     └───────────────────────────────────────────┘
         │
         ▼
┌─────────────────┐
│ 📅 BOOKING DAY  │──── Navigate, use space within booked time
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ 🎯 POST-BOOKING │
│                 │
│ • Rate space ⭐ │
│ • Rate owner ⭐ │
│ • View history  │
│ • Rebook / New  │
└─────────────────┘
```

### 🛡️ 6.3 Admin Journey

```
    ┌───────────┐
    │  LOGIN    │──── Admin credentials + 2FA
    │  (Admin)  │
    └─────┬─────┘
          │
          ▼
┌───────────────────────────────────────────────────────────────────────┐
│                        📊 ADMIN DASHBOARD                             │
│                                                                       │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐  ┌──────────┐             │
│  │ 👥 Users  │  │ 🏠 Active │  │ 📅 Today's│  │ 💰 Revenue│            │
│  │  12,450  │  │ Listings │  │ Bookings │  │ This Mo  │             │
│  │          │  │  3,820   │  │    145   │  │ ₹8.2L   │              │
│  └──────────┘  └──────────┘  └──────────┘  └──────────┘             │
│                                                                       │
│  ┌──────────┐  ┌──────────┐                                          │
│  │ ⏳ Pending│  │ ⚠️ Open   │                                         │
│  │ Approvals│  │ Disputes │                                          │
│  │    23    │  │     5    │                                           │
│  └──────────┘  └──────────┘                                          │
└───────────┬───────────────────────────────────────────────────────────┘
            │
            ├───────────┬────────────┬────────────┬────────────┐
            │           │            │            │            │
            ▼           ▼            ▼            ▼            ▼
   ┌──────────────┐ ┌─────────┐ ┌──────────┐ ┌─────────┐ ┌─────────┐
   │ 🔍 MODERATION│ │ 👤 USER  │ │ 💳 TRANS- │ │ ⚠️ DIS-  │ │ ⚙️ CON-  │
   │    QUEUE     │ │  MGMT   │ │  ACTIONS  │ │  PUTES  │ │  FIG    │
   │              │ │         │ │          │ │         │ │         │
   │ • Review new │ │ • Search│ │ • View   │ │ • Review│ │ • Set   │
   │   listings   │ │ • Filter│ │   all    │ │   issue │ │   comm  │
   │ • Preview    │ │ • View  │ │ • Filter │ │ • Both  │ │   rates │
   │ • Approve ✅ │ │   detail│ │ • Export │ │   sides │ │ • Manage│
   │ • Reject ❌  │ │ • Ban 🚫│ │ • Payouts│ │ • Refund│ │   types │
   │ • Flag ⚠️    │ │ • Warn  │ │ • Refunds│ │ • Warn  │ │ • Notif │
   └──────────────┘ └─────────┘ └──────────┘ └─────────┘ └─────────┘
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--             SECTION 7: FUNCTIONAL REQUIREMENTS                    -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 📝 7. Functional Requirements

</div>

---

> **Priority Key:** 🔴 P0 = Must Have (MVP) | 🟡 P1 = Should Have | 🟢 P2 = Nice to Have

### 7.1 👤 User Management

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| UM-01 | User registration | 🔴 P0 | Email + password, or Google/Apple OAuth. Phone OTP verification mandatory. |
| UM-02 | User login | 🔴 P0 | Email/password + OAuth. JWT-based session management. |
| UM-03 | Role selection | 🔴 P0 | User selects: "List a space" / "Book a space" / Both. Changeable later. |
| UM-04 | Profile management | 🔴 P0 | Name, phone, email, photo, bio, govt ID upload (for owners). |
| UM-05 | KYC verification (Owners) | 🟡 P1 | Government ID + address proof. Admin verifies before first listing goes live. |
| UM-06 | Password reset | 🔴 P0 | Email-based OTP flow. |
| UM-07 | Account deactivation | 🟢 P2 | User deactivates account. Active bookings must complete/cancel first. |
| UM-08 | Session management | 🔴 P0 | Auto-logout after 30 days inactivity. Multi-device sessions. |

---

### 7.2 🏠 Space Listing (Owner)

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| SL-01 | Create listing | 🔴 P0 | Multi-step form: Basic Info → Amenities → Pricing → Availability → Photos → House Rules → Submit |
| SL-02 | Space types | 🔴 P0 | Categories: Room, Hall, Terrace, Classroom, Conference Room, Studio, Open Space, Other |
| SL-03 | **Mandatory amenities** | 🔴 P0 | Every listing MUST specify: |

> **Mandatory Amenity Checklist (SL-03):**
>
> ```
> ┌──────────────────────────────────────────────────────────────┐
> │              ⚠️ REQUIRED FOR EVERY LISTING                    │
> ├──────────────────────────────────────────────────────────────┤
> │                                                              │
> │  📶 WiFi            →  Yes / No / Speed (Mbps)              │
> │  🪑 Chairs          →  Count (number)                       │
> │  🪵 Tables          →  Count (number)                       │
> │  🎯 Event Suitability → Multi-select:                       │
> │                         □ Meeting    □ Tuition               │
> │                         □ Workshop   □ Gathering             │
> │                         □ Party      □ Photography           │
> │                         □ Yoga/Fitness  □ Other              │
> │                                                              │
> └──────────────────────────────────────────────────────────────┘
> ```

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| SL-04 | Optional amenities | 🔴 P0 | Checklist: AC, Projector, Whiteboard, Parking (free/paid), Refreshments, Power Outlets, Sound System, Restroom, Kitchen, Elevator, Wheelchair Accessible |
| SL-05 | Image upload | 🔴 P0 | Min 3, max 15 photos. JPG/PNG. Max 10MB each. Auto-compress. |
| SL-06 | Video upload | 🟡 P1 | Optional. Max 1 video, 60 sec, 100MB, MP4. |
| SL-07 | Pricing config | 🔴 P0 | Hourly rate (INR), Daily rate (optional). Min booking duration (1 hr default). |
| SL-08 | Availability calendar | 🔴 P0 | Recurring weekly schedule OR specific date/time slots. Block dates. Real-time sync. |
| SL-09 | House rules | 🟡 P1 | Free-text + toggles: No smoking, No alcohol, No pets, No loud music, Shoes off, Max occupancy. |
| SL-10 | Cancellation policy | 🟡 P1 | Flexible (refund 24hr before) / Moderate (72hr) / Strict (50% refund 7 days). |
| SL-11 | Location | 🔴 P0 | Address + Google Maps pin. Approx location in search; exact after booking. |
| SL-12 | Listing moderation | 🔴 P0 | New → "Pending Review". Admin approves/rejects within 24-48 hrs. |
| SL-13 | Edit listing | 🔴 P0 | All fields editable. Significant changes trigger re-review. |
| SL-14 | Pause / Unpause | 🟡 P1 | Temporarily hide without deleting. |
| SL-15 | Delete listing | 🟡 P1 | Soft delete. Blocked if active bookings exist. |
| SL-16 | Maximum capacity | 🔴 P0 | Owner specifies max people. Displayed prominently. |
| SL-17 | Listing analytics | 🟢 P2 | Views, booking requests, acceptance rate, earnings graph. |

---

### 7.3 🔍 Search & Discovery (Renter)

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| SD-01 | Location-based search | 🔴 P0 | Search by city/area/pin code. GPS auto-detect. Radius filter (1-25 km). |
| SD-02 | Map view | 🟡 P1 | Google Maps with listing pins. Click for quick preview. |
| SD-03 | List view | 🔴 P0 | Cards: thumbnail, title, price, rating, amenities, distance. |
| SD-04 | Filters | 🔴 P0 | Price range, Space type, Event type, Amenities, Date/time, Capacity, Rating. |
| SD-05 | Sort options | 🔴 P0 | Relevance, Price ↑↓, Rating, Distance, Newest. |
| SD-06 | Search autocomplete | 🟡 P1 | Location suggestions. Recent searches. |
| SD-07 | Listing detail page | 🔴 P0 | Full gallery, amenities, pricing, availability, rules, owner profile, reviews, "Request Booking" CTA. |
| SD-08 | Similar spaces | 🟢 P2 | "You might also like" based on area + event type. |
| SD-09 | Save / Wishlist | 🟡 P1 | Renter saves listings for later. |
| SD-10 | Recently viewed | 🟢 P2 | Last 10 viewed listings on home screen. |

---

### 7.4 📅 Booking

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| BK-01 | Time slot selection | 🔴 P0 | Calendar + hourly slots. Grey = unavailable. Multi-slot for consecutive hours. |
| BK-02 | Booking request | 🔴 P0 | Renter submits: selected slots, guest count, purpose note (optional). |
| BK-03 | Owner response | 🔴 P0 | Notification sent. Must respond within 24 hrs. Options: Accept / Reject / Counter-offer. |
| BK-04 | Auto-expiry | 🔴 P0 | No response in 24 hrs → auto-cancel. Renter notified. No charge. |
| BK-05 | Counter-offer flow | 🟡 P1 | Owner proposes alternate time/price. Renter accepts/declines. 12 hr expiry. |
| BK-06 | Booking confirmation | 🔴 P0 | On accept: payment captured, both notified, address revealed, calendar updated. |
| BK-07 | Renter cancellation | 🔴 P0 | Refund per cancellation policy (Flexible/Moderate/Strict). |
| BK-08 | Owner cancellation | 🔴 P0 | Full refund to renter. Penalty flag if > 3 cancellations in 30 days. |
| BK-09 | Booking modification | 🟡 P1 | Either party requests time change. Other approves. Subject to availability. |
| BK-10 | Booking statuses | 🔴 P0 | States: `Requested → Accepted/Rejected/Counter-offered/Expired → Confirmed → In Progress → Completed → Cancelled` |
| BK-11 | Booking history | 🔴 P0 | Past + upcoming bookings with full details. |
| BK-12 | Check-in / Check-out | 🟢 P2 | Optional OTP-based check-in for dispute evidence. |
| BK-13 | Double-booking prevention | 🔴 P0 | Real-time availability lock during payment processing. |

---

### 7.5 💳 Payments

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| PY-01 | Gateway integration | 🔴 P0 | Razorpay or Stripe. UPI, Cards, Net banking, Wallets. |
| PY-02 | Pricing breakdown | 🔴 P0 | Display: Base price, Service fee (%), GST, Total. |
| PY-03 | Payment hold | 🔴 P0 | Authorized on request. Captured on acceptance. Released if rejected/expired. |
| PY-04 | Owner payout | 🔴 P0 | Payout = Base - Commission. Within 24-48 hrs after booking completion. |
| PY-05 | Payout methods | 🔴 P0 | Bank account (IFSC + A/C) or UPI ID. |
| PY-06 | Refund processing | 🔴 P0 | Auto per policy. Manual via admin for disputes. 5-7 business days. |
| PY-07 | Invoice generation | 🟡 P1 | Auto-generated PDF invoice per booking. |
| PY-08 | Transaction history | 🔴 P0 | Date, amount, booking ID, status, commission — for all parties. |
| PY-09 | Failed payment handling | 🔴 P0 | Retry (up to 3). Notification on failure. Booking unconfirmed until success. |
| PY-10 | Earnings dashboard | 🟡 P1 | Total, pending, commission, monthly breakdown, CSV export. |

---

### 7.6 🔔 Notifications

| Req ID | Trigger | Priority | 📱 Push | 📧 Email | 🔔 In-App |
|:------:|:--------|:--------:|:-------:|:--------:|:---------:|
| NT-01 | Booking request received (→ Owner) | 🔴 P0 | ✅ | ✅ | ✅ |
| NT-02 | Booking accepted (→ Renter) | 🔴 P0 | ✅ | ✅ | ✅ |
| NT-03 | Booking rejected (→ Renter) | 🔴 P0 | ✅ | — | ✅ |
| NT-04 | Counter-offer sent (→ Renter) | 🟡 P1 | ✅ | ✅ | ✅ |
| NT-05 | Counter-offer response (→ Owner) | 🟡 P1 | ✅ | — | ✅ |
| NT-06 | Booking expired / auto-cancelled | 🔴 P0 | ✅ | — | ✅ |
| NT-07 | Payment confirmed (→ Both) | 🔴 P0 | ✅ | ✅ | ✅ |
| NT-08 | Payment failed (→ Renter) | 🔴 P0 | ✅ | ✅ | — |
| NT-09 | Reminder: 24 hrs before (→ Both) | 🔴 P0 | ✅ | — | ✅ |
| NT-10 | Reminder: 1 hr before (→ Both) | 🟡 P1 | ✅ | — | — |
| NT-11 | Booking completed — "Rate now" | 🔴 P0 | ✅ | — | ✅ |
| NT-12 | Booking cancelled (→ Other party) | 🔴 P0 | ✅ | ✅ | ✅ |
| NT-13 | Payout processed (→ Owner) | 🔴 P0 | ✅ | ✅ | — |
| NT-14 | Listing approved/rejected (→ Owner) | 🔴 P0 | ✅ | ✅ | ✅ |
| NT-15 | New review received | 🟡 P1 | ✅ | — | ✅ |
| NT-16 | Promotional / Marketing | 🟢 P2 | ✅ | ✅ | — |

---

### 7.7 ⭐ Ratings & Reviews

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| RR-01 | Post-booking rating | 🔴 P0 | Both parties rate each other (1-5 stars). Prompted after completion. |
| RR-02 | Review text | 🔴 P0 | Optional written review, max 500 characters. |
| RR-03 | Rating categories (Space) | 🟡 P1 | Overall, Cleanliness, Accuracy, Value for money, Amenities. |
| RR-04 | Rating categories (Renter) | 🟡 P1 | Overall, Communication, Punctuality, Rule compliance. |
| RR-05 | Simultaneous reveal | 🔴 P0 | Both reviews shown after both submit (or 14-day window). |
| RR-06 | Review moderation | 🟡 P1 | Admin flags/removes profanity, personal attacks, spam. |
| RR-07 | Aggregate display | 🔴 P0 | Average rating on cards + detail page. Individual reviews listed. |
| RR-08 | Owner response | 🟢 P2 | Owner can post a public reply to renter's review. |

---

### 7.8 🛠️ Admin Panel

| Req ID | Requirement | Priority | Details |
|:------:|:-----------|:--------:|:--------|
| AP-01 | Dashboard | 🔴 P0 | KPIs: Users, Active listings, Bookings (today/week/month), Revenue, Pending approvals, Disputes. Trend charts. |
| AP-02 | User management | 🔴 P0 | Search/filter. View profile + activity. Suspend / Ban with reason. |
| AP-03 | Listing moderation | 🔴 P0 | Pending queue. Preview listing. Approve / Reject. Bulk actions. |
| AP-04 | Transaction monitoring | 🔴 P0 | All transactions with filters. Export CSV. |
| AP-05 | Payout management | 🔴 P0 | Pending list. Approve/process. Hold for disputed bookings. |
| AP-06 | Dispute management | 🔴 P0 | View reports. Booking timeline. Refund / Partial refund / Warn / Suspend. |
| AP-07 | Commission config | 🔴 P0 | Set rate (%). Global, category-wise, or promotional (time-bound). |
| AP-08 | Content management | 🟡 P1 | Manage categories, amenities, event types. |
| AP-09 | Notification management | 🟡 P1 | Configure templates. Broadcast announcements. |
| AP-10 | Reports & analytics | 🟡 P1 | Revenue, User growth, Booking trends, Top listings. Downloadable. |
| AP-11 | Admin roles | 🟡 P1 | Super Admin (full), Moderator (listings + disputes), Finance (transactions + payouts). |
| AP-12 | Audit log | 🟢 P2 | All admin actions logged with timestamp + admin ID. |

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--           SECTION 8: NON-FUNCTIONAL REQUIREMENTS                  -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## ⚙️ 8. Non-Functional Requirements

</div>

---

### ⚡ Performance

| NFR ID | Requirement | Target |
|:------:|:-----------|:------:|
| NFR-01 | Page load time (web) | < **2 seconds** |
| NFR-02 | Page load time (mobile) | < **1.5 seconds** |
| NFR-03 | Search results response | < **500ms** |
| NFR-04 | API response (P95) | < **300ms** |

### 📈 Scalability

| NFR ID | Requirement | Target |
|:------:|:-----------|:------:|
| NFR-05 | Concurrent users at launch | **10,000** (scalable to 100K+) |
| NFR-06 | Database capacity | **100K+** listings, **1M+** bookings |

### 🛡️ Availability & Disaster Recovery

| NFR ID | Requirement | Target |
|:------:|:-----------|:------:|
| NFR-07 | Uptime SLA | **99.5%** |
| NFR-08 | Recovery Point Objective (RPO) | **1 hour** |
| NFR-09 | Recovery Time Objective (RTO) | **4 hours** |

### 🔐 Security

| NFR ID | Requirement | Details |
|:------:|:-----------|:--------|
| NFR-10 | Authentication | JWT + refresh tokens. OAuth 2.0. Access token: 15 min. Refresh: 7 days. |
| NFR-11 | Authorization | Role-based access control (RBAC). API-level permission checks. |
| NFR-12 | Encryption (transit) | TLS 1.2+ for all communications. |
| NFR-13 | Encryption (at rest) | AES-256 for sensitive data (passwords, payment tokens). |
| NFR-14 | Password policy | Min 8 chars, 1 uppercase, 1 number, 1 special. Bcrypt hashing. |
| NFR-15 | Payment security | PCI DSS compliance via gateway. Zero card data stored on servers. |

### 🔒 Privacy & Compliance

| NFR ID | Requirement | Details |
|:------:|:-----------|:--------|
| NFR-16 | Data compliance | GDPR-aware. User data deletion on request. Consent-based marketing. |
| NFR-17 | Location privacy | Exact address hidden until booking confirmed. ~500m radius shown in search. |

### 🌐 Compatibility

| NFR ID | Requirement | Target |
|:------:|:-----------|:------:|
| NFR-18 | Browser support | Chrome, Safari, Firefox, Edge (latest 2 versions) |
| NFR-19 | Mobile support | Android 9+ / iOS 14+ |
| NFR-20 | Accessibility | WCAG 2.1 Level AA. Screen reader support. |

### 📊 Monitoring

| NFR ID | Requirement | Details |
|:------:|:-----------|:--------|
| NFR-21 | Logging | Centralized (ELK / CloudWatch). |
| NFR-22 | Alerting | Downtime, error rate > 1%, payment failures — auto-escalated. |

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--           SECTION 9: SYSTEM ARCHITECTURE & MODULES                -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 🏗️ 9. System Architecture & Modules

</div>

---

### 9.1 High-Level Architecture

```
╔══════════════════════════════════════════════════════════════════════════╗
║                        📱 CLIENT APPLICATIONS                          ║
║                                                                        ║
║    ┌──────────────────────┐        ┌──────────────────────┐           ║
║    │   🌐 Web Application  │        │  📱 Mobile Apps       │           ║
║    │   (React / Next.js)  │        │  (Flutter / MAUI)    │           ║
║    │                      │        │  Android + iOS       │           ║
║    └──────────┬───────────┘        └──────────┬───────────┘           ║
╚═══════════════╪════════════════════════════════╪═══════════════════════╝
                │              HTTPS             │
                └──────────────┬─────────────────┘
                               │
╔══════════════════════════════╪══════════════════════════════════════════╗
║                              ▼                                         ║
║              ┌──────────────────────────────┐                          ║
║              │       🔀 API GATEWAY          │                         ║
║              │                              │                          ║
║              │  • Rate Limiting             │                          ║
║              │  • JWT Validation            │                          ║
║              │  • Request Routing           │                          ║
║              │  • CORS / Security Headers   │                          ║
║              └──────────────┬───────────────┘                          ║
║                             │                                          ║
║    ┌────────────────────────┼────────────────────────┐                 ║
║    │            │           │           │            │                 ║
║    ▼            ▼           ▼           ▼            ▼                 ║
║ ┌────────┐ ┌────────┐ ┌────────┐ ┌────────┐ ┌────────────┐           ║
║ │👤 USER  │ │🏠 LIST-│ │📅 BOOK-│ │💳 PAY- │ │⭐ REVIEW   │           ║
║ │SERVICE │ │ING    │ │ING    │ │MENT   │ │  SERVICE  │            ║
║ │        │ │SERVICE│ │SERVICE│ │SERVICE│ │           │            ║
║ └────┬───┘ └───┬───┘ └───┬───┘ └───┬───┘ └─────┬────┘            ║
║      │         │         │         │            │                  ║
║      │    ┌────┴────┐    │         │            │                  ║
║      │    │🔍 SEARCH │    │         │            │                  ║
║      │    │ SERVICE  │    │         │            │                  ║
║      │    │(Elastic- │    │         │            │                  ║
║      │    │ search)  │    │         │            │                  ║
║      │    └─────────┘    │         │            │                  ║
║      │                   │         │            │                  ║
║      │    ┌──────────────┘         │            │                  ║
║      │    │    ┌───────────────────┘            │                  ║
║      │    │    │    ┌───────────────────────────┘                  ║
║      │    │    │    │                                              ║
║      ▼    ▼    ▼    ▼                                              ║
║ ┌──────────────────────────────┐  ┌──────────────────────────┐     ║
║ │  🔔 NOTIFICATION SERVICE     │  │  📊 ANALYTICS SERVICE     │     ║
║ │                              │  │                          │     ║
║ │  • FCM (Push)                │  │  • Event tracking        │     ║
║ │  • SES / SendGrid (Email)   │  │  • KPI computation       │     ║
║ │  • In-App WebSocket         │  │  • Reporting             │     ║
║ └──────────────────────────────┘  └──────────────────────────┘     ║
║                                                                     ║
╠═════════════════════════════════════════════════════════════════════╣
║                        💾 DATA LAYER                                ║
║                                                                     ║
║  ┌───────────────┐  ┌────────────┐  ┌──────────────┐  ┌────────┐  ║
║  │ 🐘 PostgreSQL  │  │ 🔴 Redis    │  │ ☁️ S3 / Blob  │  │🔍 Elastic│ ║
║  │               │  │            │  │              │  │ search │  ║
║  │ Primary DB    │  │ Cache +    │  │ Images,      │  │        │  ║
║  │ (all entities)│  │ Sessions   │  │ Videos,      │  │ Search │  ║
║  │               │  │ + Queues   │  │ Invoices     │  │ Index  │  ║
║  └───────────────┘  └────────────┘  └──────────────┘  └────────┘  ║
║                                                                     ║
╚═════════════════════════════════════════════════════════════════════╝
```

### 9.2 Module Breakdown

| Module | Description | Key Entities |
|:-------|:-----------|:-------------|
| 🔐 **Auth & Identity** | Registration, login, JWT, OAuth, OTP, password mgmt | User, Session, OTP, KYCDocument |
| 👤 **Profile** | User profile CRUD, role management, KYC status | UserProfile, KYCVerification |
| 🏠 **Listing** | Space CRUD, media, amenities, pricing, availability, moderation | Listing, ListingMedia, Amenity, Availability, PricingRule |
| 🔍 **Search** | Geo-spatial search, filtering, sorting, autocomplete | SearchIndex (Elasticsearch) |
| 📅 **Booking** | Request flow, responses, status mgmt, calendar blocking | Booking, BookingSlot, CounterOffer |
| 💳 **Payment** | Gateway, hold/capture, refunds, payouts, invoicing | Transaction, Payout, Invoice, Refund |
| 🔔 **Notification** | Multi-channel delivery, templates, scheduling | Notification, Template, Preference |
| ⭐ **Review** | Ratings, aggregation, moderation, responses | Review, Rating, ReviewReport |
| 🛠️ **Admin** | Dashboard, moderation, config, disputes, reports | AdminAction, Dispute, CommissionConfig, AuditLog |

### 9.3 Core Database Schema

```
╔══════════════════════════════════════════════════════════════════════════╗
║                         📊 ENTITY RELATIONSHIP                         ║
╠══════════════════════════════════════════════════════════════════════════╣
║                                                                        ║
║  ┌─────────────────┐                                                   ║
║  │     👤 USERS      │                                                  ║
║  │─────────────────│                                                   ║
║  │ id (PK)         │                                                   ║
║  │ email           │          ┌─────────────────────┐                  ║
║  │ phone           │    1:N   │    🏠 LISTINGS       │                  ║
║  │ password_hash   │─────────▶│─────────────────────│                  ║
║  │ role            │          │ id (PK)             │                  ║
║  │ kyc_status      │          │ owner_id (FK→Users) │                  ║
║  │ is_active       │          │ title, description  │                  ║
║  │ created_at      │          │ space_type, capacity│                  ║
║  └────────┬────────┘          │ lat, lng, address   │                  ║
║           │                   │ hourly_rate         │                  ║
║           │                   │ daily_rate          │                  ║
║           │                   │ cancellation_policy │                  ║
║           │                   │ status (pending/    │                  ║
║           │                   │  active/paused/     │                  ║
║           │                   │  rejected)          │                  ║
║           │                   └──────┬──────────────┘                  ║
║           │                          │                                 ║
║           │              ┌───────────┼───────────────┐                 ║
║           │              │           │               │                 ║
║           │              ▼           ▼               ▼                 ║
║           │    ┌──────────────┐ ┌─────────┐ ┌──────────────┐          ║
║           │    │📸 LISTING_   │ │🔗 LIST- │ │📅 AVAILABIL- │          ║
║           │    │   MEDIA      │ │ING_     │ │ITY_SLOTS     │          ║
║           │    │──────────────│ │AMENITIES│ │──────────────│          ║
║           │    │ id (PK)      │ │─────────│ │ id (PK)      │          ║
║           │    │ listing_id   │ │ list_id │ │ listing_id   │          ║
║           │    │ url          │ │ amen_id │ │ day_of_week  │          ║
║           │    │ type (img/   │ └─────────┘ │ start_time   │          ║
║           │    │  video)      │      │      │ end_time     │          ║
║           │    └──────────────┘      │      └──────────────┘          ║
║           │                          │                                 ║
║           │                          ▼                                 ║
║           │                  ┌──────────────┐                          ║
║           │                  │ 🪑 AMENITIES  │                         ║
║           │                  │──────────────│                          ║
║           │                  │ id (PK)      │                          ║
║           │                  │ name         │                          ║
║           │                  │ category     │                          ║
║           │                  │ (mandatory/  │                          ║
║           │                  │  optional)   │                          ║
║           │                  └──────────────┘                          ║
║           │                                                            ║
║           │   1:N                                                      ║
║           ├─────────▶┌─────────────────────┐                          ║
║           │          │    📅 BOOKINGS        │                         ║
║           │          │─────────────────────│                          ║
║           │          │ id (PK)             │                          ║
║           │          │ listing_id (FK)     │                          ║
║           │          │ renter_id (FK)      │                          ║
║           │          │ owner_id (FK)       │                          ║
║           │          │ booking_date        │                          ║
║           │          │ start_time, end_time│                          ║
║           │          │ guest_count         │                          ║
║           │          │ status (requested/  │                          ║
║           │          │  accepted/rejected/ │                          ║
║           │          │  confirmed/completed│                          ║
║           │          │  /cancelled/expired)│                          ║
║           │          │ base_amount         │                          ║
║           │          │ service_fee, tax    │                          ║
║           │          │ total_amount        │                          ║
║           │          └──────┬──────────────┘                          ║
║           │                 │                                          ║
║           │          ┌──────┼──────────────┐                          ║
║           │          │      │              │                          ║
║           │          ▼      ▼              ▼                          ║
║           │  ┌────────────┐ ┌──────────┐ ┌──────────────┐            ║
║           │  │💳 TRANSAC-  │ │🔄 COUNTER│ │⭐ REVIEWS    │           ║
║           │  │  TIONS     │ │ _OFFERS  │ │──────────────│            ║
║           │  │────────────│ │──────────│ │ id (PK)      │            ║
║           │  │ id (PK)    │ │ id (PK)  │ │ booking_id   │            ║
║           │  │ booking_id │ │ book_id  │ │ author_id    │            ║
║           │  │ gateway_id │ │ new_time │ │ target_id    │            ║
║           │  │ amount     │ │ new_price│ │ rating (1-5) │            ║
║           │  │ commission │ │ status   │ │ review_text  │            ║
║           │  │ payout_amt │ │ expires  │ │ is_visible   │            ║
║           │  │ status     │ └──────────┘ └──────────────┘            ║
║           │  │ payout_date│                                           ║
║           │  └────────────┘                                           ║
║           │                                                            ║
║           │   1:N                                                      ║
║           └─────────▶┌──────────────────┐                             ║
║                      │ 🔔 NOTIFICATIONS  │                             ║
║                      │──────────────────│                             ║
║                      │ id, user_id      │                             ║
║                      │ type, title      │                             ║
║                      │ message, is_read │                             ║
║                      │ created_at       │                             ║
║                      └──────────────────┘                             ║
╚══════════════════════════════════════════════════════════════════════════╝
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--              SECTION 10: DATA FLOW DIAGRAMS                       -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 🔄 10. Data Flow Diagrams

</div>

---

### 10.1 Booking & Payment Flow

```
  👤 RENTER              🖥️ BOOKQWIK PLATFORM              👤 OWNER              💳 PAYMENT GATEWAY
      │                          │                            │                          │
      │  ① Select slots &       │                            │                          │
      │     submit request      │                            │                          │
      │ ─────────────────────▶  │                            │                          │
      │                         │                            │                          │
      │                         │  ② Validate availability   │                          │
      │                         │     (check calendar,       │                          │
      │                         │      prevent double-book)  │                          │
      │                         │                            │                          │
      │                         │  ③ Authorize payment ──────┼──────────────────────▶   │
      │                         │                            │                          │
      │                         │                            │    ④ Payment HELD        │
      │                         │  ◀─────────────────────────┼──────────────────────    │
      │                         │                            │                          │
      │                         │  ⑤ Send booking request ──▶│                          │
      │                         │     notification (push +   │                          │
      │                         │     email + in-app)        │                          │
      │                         │                            │                          │
      │                         │                  ⑥ Owner   │                          │
      │                         │  ◀──────────────── reviews │                          │
      │                         │                   request  │                          │
      │                         │                            │                          │
      │        ╔════════════════╧══════════════╗              │                          │
      │        ║    OWNER DECISION BRANCH      ║              │                          │
      │        ╚════════════════╤══════════════╝              │                          │
      │                         │                            │                          │
      │            ┌────────────┼────────────┐               │                          │
      │            │            │            │               │                          │
      │            ▼            ▼            ▼               │                          │
      │     ┌──────────┐ ┌──────────┐ ┌──────────┐          │                          │
      │     │ ✅ ACCEPT │ │ ❌ REJECT │ │ 🔄 COUNTER│          │                          │
      │     └─────┬────┘ └─────┬────┘ └─────┬────┘          │                          │
      │           │            │            │               │                          │
      │           ▼            ▼            ▼               │                          │
      │     ┌──────────┐ ┌──────────┐ ┌──────────────────┐  │                          │
      │     │ ⑦ Capture │ │ ⑦ Release│ │ ⑦ Notify renter  │  │                          │
      │     │  payment  │ │  held    │ │  with new terms  │  │                          │
      │     │ ─────────▶│ │  payment │ │  (12hr expiry)   │  │                          │
      │     │           │ │ ────────▶│ └──────────────────┘  │                          │
      │     │           │ │          │                       │                          │
      │     │    ⑧ Both │ │  ⑧ Renter│                       │                          │
      │  ◀──┤  notified │ │◀─notified│                       │                          │
      │     │ "Booking  │ │ "Request │                       │                          │
      │     │ Confirmed"│ │ Declined"│                       │                          │
      │     └──────────┘ └──────────┘                       │                          │
      │                                                      │                          │
      │        ═══════ AFTER BOOKING COMPLETED ═══════       │                          │
      │                                                      │                          │
      │                         │  ⑨ Calculate payout:       │                          │
      │                         │     Payout = Base - 5%     │                          │
      │                         │                            │                          │
      │                         │  ⑩ Process payout ─────────┼──────────────────────▶   │
      │                         │                            │                          │
      │                         │                            │    ⑪ Payout sent to      │
      │                         │                            │◀──── owner's bank        │
      │                         │                            │                          │
      │                         │  ⑫ "Payout processed" ───▶│                          │
      │                         │     notification           │                          │
      │                         │                            │                          │
      │  ⑬ "Rate your          │                            │  ⑬ "Rate your            │
      │◀───experience" ────────│────────────────────────────│──── renter" ────▶        │
      │                         │                            │                          │
      ▼                         ▼                            ▼                          ▼
```

### 10.2 Listing Moderation Flow

```
  👤 OWNER                    🖥️ BOOKQWIK PLATFORM                   🛡️ ADMIN
      │                              │                                   │
      │  ① Submit new listing        │                                   │
      │ ──────────────────────────▶  │                                   │
      │                              │                                   │
      │                              │  ② Store listing                  │
      │                              │     status = "PENDING" ⏳         │
      │                              │                                   │
      │                              │  ③ Add to moderation ────────────▶│
      │                              │     queue                         │
      │                              │                                   │
      │                              │                         ④ Admin   │
      │                              │                           reviews:│
      │                              │                                   │
      │                              │                    ┌──────────────┤
      │                              │                    │  • Check     │
      │                              │                    │    photos    │
      │                              │                    │  • Verify    │
      │                              │                    │    info      │
      │                              │                    │  • Check     │
      │                              │                    │    location  │
      │                              │                    │  • Review    │
      │                              │                    │    pricing   │
      │                              │                    └──────┬───────┤
      │                              │                           │       │
      │                   ┌──────────┼───────────────────────────┘       │
      │                   │          │                                   │
      │            ┌──────┴──────┐   │                                   │
      │            │             │   │                                   │
      │            ▼             ▼   │                                   │
      │     ┌────────────┐ ┌────────────┐                               │
      │     │ ✅ APPROVE  │ │ ❌ REJECT   │                              │
      │     └──────┬─────┘ └──────┬─────┘                               │
      │            │              │                                      │
      │            ▼              ▼                                      │
      │     ┌────────────┐ ┌────────────┐                               │
      │     │ Status →   │ │ Status →   │                               │
      │     │ "ACTIVE" ✅│ │ "REJECTED" │                               │
      │     │            │ │ + reason   │                               │
      │     │ Added to   │ │            │                               │
      │     │ search     │ │ Can edit & │                               │
      │     │ index 🔍   │ │ resubmit   │                               │
      │     └──────┬─────┘ └──────┬─────┘                               │
      │            │              │                                      │
      │  ◀─────────┴──────────────┘                                     │
      │     ⑤ Notification:                                             │
      │     "Your listing has been                                      │
      │      approved/rejected"                                         │
      │     (push + email + in-app)                                     │
      │                                                                  │
      ▼                                                                  ▼
```

### 10.3 Booking State Machine

```
                                 ┌──────────────┐
                                 │  📝 REQUESTED │ ◀──── Renter submits
                                 └──────┬───────┘
                                        │
                     ┌──────────────────┼──────────────────┬───────────────────┐
                     │                  │                  │                   │
                     ▼                  ▼                  ▼                   ▼
              ┌──────────┐      ┌──────────┐      ┌──────────────┐    ┌──────────┐
              │✅ ACCEPTED│      │❌ REJECTED│      │🔄 COUNTER-   │    │⏰ EXPIRED │
              │          │      │          │      │   OFFERED    │    │          │
              └─────┬────┘      └──────────┘      └──────┬───────┘    └──────────┘
                    │                                     │           (24hr timeout)
                    │                            ┌────────┼────────┐
                    │                            │                 │
                    │                            ▼                 ▼
                    │                    ┌──────────┐      ┌──────────┐
                    │                    │✅ ACCEPTED│      │❌ DECLINED│
                    │                    │ by Renter │      │ by Renter│
                    │                    └─────┬────┘      └──────────┘
                    │                          │
                    └──────────────┬────────────┘
                                   │
                                   ▼
                           ┌──────────────┐
                           │ ✅ CONFIRMED  │ ◀──── Payment captured
                           └──────┬───────┘
                                  │
                            ┌─────┴──────┐
                            │            │
                            ▼            ▼
                    ┌──────────┐  ┌──────────────┐
                    │🚫 CANCEL-│  │▶️ IN PROGRESS │ ◀──── Start time reached
                    │  LED     │  └──────┬───────┘
                    └──────────┘         │
                                         ▼
                                 ┌──────────────┐
                                 │ 🏁 COMPLETED  │ ◀──── End time passed
                                 └──────────────┘
                                        │
                                        ▼
                                ┌───────────────┐
                                │ ⭐ Rate & Review│
                                │   + Payout     │
                                └───────────────┘
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--            SECTION 11: ASSUMPTIONS & CONSTRAINTS                  -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 📌 11. Assumptions & Constraints

</div>

---

### 💡 11.1 Assumptions

| # | Assumption | ⚠️ Impact if Wrong |
|:-:|:-----------|:-------------------|
| A-1 | Target market: **urban India** (Bangalore, Hyderabad, Mumbai, Pune, Delhi NCR) | Marketing & regulatory research must broaden |
| A-2 | Users have **smartphones with internet** | May need SMS fallbacks / offline features |
| A-3 | Owners willing to rent **hourly to strangers** | Need stronger trust/safety; on-ground onboarding |
| A-4 | Average booking value: **INR 500 - 5,000** | Revenue projections & commission model change |
| A-5 | **Razorpay** supports hold/capture/release/refund/payout | May need to evaluate Cashfree, PayU |
| A-6 | **24-hour owner response** time is acceptable | May need "Instant Book" feature earlier |
| A-7 | Team of **2-3 admins** can handle moderation (~100 listings/week) | May need automated image AI sooner |
| A-8 | **Google Maps API** for location services | Budget: ~$7/1000 requests; OpenStreetMap as backup |
| A-9 | Commission-only model (**no listing fees**) | Need strong volume for revenue targets |
| A-10 | **No special rental licenses** required in target cities | City-specific legal review needed |

### 🔒 11.2 Constraints

| # | Constraint | Mitigation |
|:-:|:-----------|:-----------|
| C-1 | MVP budget: **INR 25-30 Lakhs** | Ruthless prioritization; use SaaS tools (Firebase, Razorpay, SendGrid) |
| C-2 | MVP timeline: **4-5 months** | Agile sprints; defer P2 features |
| C-3 | Team size: **4-5 developers** | Full-stack devs; shared component libraries |
| C-4 | **No in-house payment processing** | Use established gateway; accept customization limits |
| C-5 | **Chicken-and-egg problem** (supply vs demand) | Seed 200+ spaces before renter marketing push |
| C-6 | Payment gateway fee: **2-3%** | Factor into commission; negotiate volume discounts post-scale |

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                  SECTION 12: RISK REGISTER                        -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## ⚠️ 12. Risk Register

</div>

---

| ID | Risk Description | Likelihood | Impact | Risk Score | Mitigation Strategy |
|:--:|:----------------|:----------:|:------:|:----------:|:--------------------|
| R-01 | **Low initial listing supply** | 🔴 High | 🔴 Critical | 🔴 **9** | Pre-launch on-ground onboarding of 200+ spaces. 0% commission for first 3 months to early owners. |
| R-02 | **Property damage / safety incidents** | 🟡 Medium | 🔴 Critical | 🟠 **7** | KYC verification. Renter ratings. House rules. Phase 2: damage deposit. Phase 3: insurance. |
| R-03 | **Fraudulent listings** (fake photos) | 🟡 Medium | 🟠 High | 🟠 **6** | Admin moderation. Photo guidelines. Renter reviews flag inaccuracy. |
| R-04 | **Payment disputes / chargebacks** | 🟡 Medium | 🟠 High | 🟠 **6** | Clear cancellation policies. Payment hold. Admin dispute resolution. Documented evidence. |
| R-05 | **Platform circumvention** (offline deals) | 🔴 High | 🟠 High | 🔴 **8** | Hide address until booking. Offer refund guarantees. Build convenience habit. |
| R-06 | **Poor search relevance** | 🟡 Medium | 🟠 High | 🟠 **6** | Elasticsearch. Search feedback collection. A/B test ranking. |
| R-07 | **Regulatory changes** (rental laws) | 🟢 Low | 🟠 High | 🟡 **4** | Legal monitoring. Flexible ToS. City-specific compliance. |
| R-08 | **Scalability issues under load** | 🟢 Low | 🟡 Medium | 🟢 **3** | Cloud-native. Load testing. Auto-scaling. |
| R-09 | **Low repeat booking rate** | 🟡 Medium | 🟠 High | 🟠 **6** | Post-booking engagement. Quality via reviews. Phase 2: loyalty discounts. |
| R-10 | **Competitor entry** (Airbnb expansion) | 🟢 Low | 🟡 Medium | 🟢 **3** | Hyper-local niche focus. Community building. Execution speed. |

### Risk Matrix

```
                    ┌────────────────────────────────────────────┐
                    │              IMPACT                         │
                    │     Low        Medium       High    Critical│
        ┌───────────┼───────────┬───────────┬──────────┬─────────┤
        │           │           │           │          │         │
  L  High│           │           │           │  R-05 🔴 │  R-01 🔴│
  I      │           │           │           │          │         │
  K  ────┼───────────┼───────────┼───────────┼──────────┼─────────┤
  E      │           │           │  R-03 🟠  │          │         │
  L  Med │           │           │  R-04 🟠  │          │  R-02 🟠│
  I      │           │           │  R-06 🟠  │          │         │
  H  ────┼───────────┼───────────┼──R-09 🟠──┼──────────┼─────────┤
  O      │           │  R-08 🟢  │           │  R-07 🟡 │         │
  O  Low │           │  R-10 🟢  │           │          │         │
  D      │           │           │           │          │         │
        └───────────┴───────────┴───────────┴──────────┴─────────┘
```

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                   SECTION 13: REVENUE MODEL                       -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 💰 13. Revenue Model

</div>

---

### 13.1 Commission Structure

```
╔══════════════════════════════════════════════════════════════════════════╗
║                                                                        ║
║                    💰 BOOKQWIK COMMISSION MODEL                        ║
║                                                                        ║
║   ┌──────────────────┐                    ┌──────────────────┐         ║
║   │   👤 RENTER PAYS  │                    │  👤 OWNER EARNS   │        ║
║   │                  │                    │                  │         ║
║   │  Base Price      │   ──────────▶      │  Base Price      │         ║
║   │  + 10% Svc Fee   │                    │  - 5% Platform   │         ║
║   │  + 18% GST on fee│                    │    Fee           │         ║
║   │  ════════════════ │                    │  ════════════════ │        ║
║   │  = Total Payable  │                    │  = Payout Amount │         ║
║   └──────────────────┘                    └──────────────────┘         ║
║                                                                        ║
║                    ┌──────────────────────┐                            ║
║                    │  🏦 BOOKQWIK KEEPS    │                           ║
║                    │                      │                            ║
║                    │  10% (from renter)   │                            ║
║                    │  + 5% (from owner)   │                            ║
║                    │  ═══════════════════  │                           ║
║                    │  = ~15% take rate    │                            ║
║                    │  - 2.5% gateway fee  │                            ║
║                    │  ═══════════════════  │                           ║
║                    │  = ~12.5% net rev    │                            ║
║                    └──────────────────────┘                            ║
║                                                                        ║
╚══════════════════════════════════════════════════════════════════════════╝
```

### 13.2 Revenue Calculation Example

```
╔══════════════════════════════════════════════════════════════════════════╗
║  📋 EXAMPLE: 4-hour booking @ INR 500/hr                              ║
╠══════════════════════════════════════════════════════════════════════════╣
║                                                                        ║
║   RENTER SIDE                          OWNER SIDE                      ║
║   ───────────                          ──────────                      ║
║   Base (4 × ₹500)    = ₹ 2,000        Base received    = ₹ 2,000     ║
║   Service fee (10%)   = ₹   200        Platform fee(5%) = ₹   100     ║
║   GST (18% on fee)    = ₹    36        ────────────────────────────    ║
║   ─────────────────────────────        Owner payout     = ₹ 1,900     ║
║   Total paid          = ₹ 2,236                                       ║
║                                                                        ║
║   PLATFORM REVENUE                                                     ║
║   ────────────────                                                     ║
║   Renter fee          = ₹   200                                       ║
║   Owner fee           = ₹   100                                       ║
║   Gross revenue       = ₹   300                                       ║
║   Gateway fee (~2.5%) = ₹    56                                       ║
║   ─────────────────────────────                                        ║
║   Net revenue         = ₹   244   ✅                                  ║
║                                                                        ║
╚══════════════════════════════════════════════════════════════════════════╝
```

### 13.3 Revenue Projections (Year 1)

| Quarter | Active Listings | Monthly Bookings | Avg Value (INR) | Monthly GTV | Monthly Net Rev |
|:-------:|:---------------:|:----------------:|:---------------:|:-----------:|:---------------:|
| Q1 | 500 | 200 | 1,500 | ₹ 3,00,000 | ₹ 36,000 |
| Q2 | 1,500 | 800 | 1,800 | ₹ 14,40,000 | ₹ 1,72,800 |
| Q3 | 3,000 | 2,500 | 2,000 | ₹ 50,00,000 | ₹ 6,00,000 |
| Q4 | 5,000 | 6,000 | 2,200 | ₹ 1,32,00,000 | ₹ 15,84,000 |
| **Year 1** | | **~28,500 total** | | **~₹ 2 Cr** | **~₹ 24 Lakhs** |

### 13.4 Future Revenue Streams

| Stream | Description | Phase |
|:-------|:-----------|:-----:|
| 📌 **Featured listings** | Owners pay to boost visibility in search | Phase 2 |
| 🔄 **Subscription plans** | Monthly plans for high-volume owners (lower commission) | Phase 2 |
| 🏅 **Premium badges** | "Verified" / "SuperHost" paid badge program | Phase 2 |
| 🍽️ **Ancillary services** | Catering, AV equipment, cleaning (marketplace add-ons) | Phase 3 |
| 🏢 **Enterprise bookings** | Corporate accounts with invoicing & bulk discounts | Phase 3 |
| 📢 **Advertising** | Sponsored listings by local businesses | Phase 3 |

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                SECTION 14: FUTURE ENHANCEMENTS                    -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 🚀 14. Future Enhancements

</div>

---

### Phase 2: Growth (Month 6-12)

| Feature | Description | Business Impact |
|:--------|:-----------|:----------------|
| 🤖 **AI Recommendations** | Personalized space suggestions from booking history & browsing | +20-30% discovery & repeat bookings |
| 📈 **Dynamic Pricing** | Demand-based pricing suggestions for owners | +15% owner earnings, +10% platform revenue |
| 💬 **In-App Messaging** | Real-time chat between owner & renter | Reduce booking abandonment |
| ⚡ **Instant Book** | Auto-accept for pre-approved booking criteria | Improve conversion rates |
| 📅 **Calendar Sync** | Google Calendar & Outlook integration | Reduce double-bookings |
| 🌐 **Multi-Language** | Hindi, Kannada, Telugu, Tamil, Marathi | 3x addressable market |
| 🎁 **Referral Program** | Earn credits for referring owners & renters | Organic growth channel |
| 📊 **Advanced Analytics** | Competitive pricing, demand heatmaps for owners | Owner retention |

### Phase 3: Scale (Month 12-18)

| Feature | Description | Business Impact |
|:--------|:-----------|:----------------|
| 🛡️ **Insurance** | Optional damage protection per booking | Increase owner trust |
| 🔄 **Recurring Bookings** | Weekly/monthly auto-booking (tuition, etc.) | Lock in repeat revenue |
| 🎥 **Virtual Tours (360)** | 360-degree space previews | Boost booking confidence |
| 🔌 **API Marketplace** | Open API for aggregators & corporate tools | New distribution channels |
| 🤖 **AI Moderation** | Auto photo/content review for listings | -60% admin workload |
| 🔐 **Smart Lock Integration** | IoT keyless entry for self-service check-in | Premium experience |
| 🏙️ **Tier-2 City Expansion** | Jaipur, Lucknow, Kochi, Chandigarh | 3x market size |
| 🏢 **Corporate Dashboard** | Company-wide space booking with centralized billing | Enterprise revenue |

<br/>

---

<!-- ══════════════════════════════════════════════════════════════════ -->
<!--                        APPENDICES                                 -->
<!-- ══════════════════════════════════════════════════════════════════ -->

<div align="center">

## 📎 Appendices

</div>

---

### Appendix A: Glossary

| Term | Definition |
|:-----|:----------|
| **GTV** | Gross Transaction Value — total value of all bookings |
| **Take Rate** | % of GTV retained by BookQwik as revenue |
| **Listing** | A space published by an owner |
| **Booking** | A confirmed reservation for a specific time |
| **Counter-offer** | Alternate time/price proposal from owner |
| **Payout** | Transfer of earnings to owner's bank |
| **KYC** | Know Your Customer — identity verification |
| **RBAC** | Role-Based Access Control |
| **RPO** | Recovery Point Objective — max data loss in disaster |
| **RTO** | Recovery Time Objective — max downtime in disaster |
| **MAR** | Monthly Active Renters |

### Appendix B: Document Revision History

| Version | Date | Author | Changes |
|:-------:|:----:|:-------|:--------|
| 1.0 | April 2, 2026 | BA Team | Initial draft as SpaceRent |
| 2.0 | April 2, 2026 | BA Team | Rebranded to BookQwik; added flowcharts, visual diagrams, state machines, architecture diagrams, risk matrix |

### Appendix C: Approval Sign-off

| Role | Name | Signature | Date |
|:-----|:-----|:---------:|:----:|
| Product Sponsor | | ___________________ | ____/____/____ |
| Product Manager | | ___________________ | ____/____/____ |
| Engineering Lead | | ___________________ | ____/____/____ |
| UX Lead | | ___________________ | ____/____/____ |
| Business Analyst | | ___________________ | ____/____/____ |

<br/>

---

<div align="center">

```
╔══════════════════════════════════════════════════════════════╗
║                                                              ║
║   This document is a living artifact and will be updated     ║
║   as requirements evolve through discovery, stakeholder      ║
║   feedback, and market validation.                           ║
║                                                              ║
║   © 2026 BookQwik. All rights reserved.                      ║
║                                                              ║
╚══════════════════════════════════════════════════════════════╝
```

</div>
